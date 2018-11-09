using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using Octokit;
using Subtle.Gui.Properties;
using Subtle.Model;
using Subtle.Model.Helpers;
using Subtle.Model.Requests;
using Subtle.Model.Responses;
using Application = System.Windows.Forms.Application;
using Subtle.Model.Models;

namespace Subtle.Gui
{
    public partial class MainForm : Form
    {
        private readonly OSDbClient osdbClient;
        private readonly IGitHubClient githubClient;
        private readonly OmdbClient omdbClient;
        private OpenFileDialog fileDialog;

        public MainForm(OSDbClient osdbClient, IGitHubClient githubClient)
        {
            InitializeComponent();
            InitSearchMethods();
            InitFileDialog();

            subtitleGrid.SelectionChanged += HandleSubtitleSelectionChanged;

            this.osdbClient = osdbClient;
            this.githubClient = githubClient;
            this.omdbClient = new OmdbClient();

            WindowTitle = Application.ProductName;

#if DEBUG
            WindowTitle += " (debug)";
#endif
        }

        private string StatusText
        {
            set => statusStrip.Text = value;
        }

        private string WindowTitle
        {
            get => Text;
            set => Text = value;
        }

        /// <summary>
        /// Close this window when Escape is pressed.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void LoadFile(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }

            var hash = Crypto.HashFile(filename);
            fileNameTextBox.Text = filename;
            hashTextBox.Text = Crypto.BinaryToHex(hash);
            textSearchTextBox.Text = Path.GetFileNameWithoutExtension(filename);
            imdbIdTextBox.Text = string.Empty;

            fileNameTextBox.Enabled = true;
            searchButton.Enabled = true;

            SetSearchMethodStates();

            await GetImdbDetails(filename);
            await SearchSubtitles(filename);
        }

        private async Task GetImdbDetails(string filename)
        {
            if (!Settings.Default.SearchMethods.HasFlag(SearchMethod.Imdb))
            {
                return;
            }

            var vi = VideoInfo.Extract(filename);
            if (vi.Type == VideoType.Undefined)
            {
                return;
            }

            StatusText = "Retrieving IMDb details...";
            OmdbResponse response = new OmdbResponse();

            switch (vi.Type)
            {
                case VideoType.Movie:
                    response = await omdbClient.SearchMovieAsync(vi.Title, vi.Year);
                    break;
                case VideoType.Episode:
                    response = await omdbClient.SearchEpisodeAsync(vi.Title, vi.Season, vi.Episode);
                    break;
            }

            if (response.Success)
            {
                imdbIdTextBox.Text = response.ImdbIdTrimmed;
            }
        }

        private async Task<SubtitleSearchResultCollection> SearchSubtitles(SearchQuery[] query)
        {
            var subs = new SubtitleSearchResultCollection();

            try
            {
                subs = await osdbClient.SearchSubtitlesAsync(query);
            }
            catch (OSDbException e)
            {
                var result = MessageBox.Show(
                    $"Subtitle search failed: {e.Message}",
                    "Error",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    subs = await SearchSubtitles(query);
                }
            }

            return subs;
        }

        private async Task<SubtitleFile> DownloadSubtitle(string subId)
        {
            try
            {
                var subs = await osdbClient.DownloadSubtitlesAsync(subId);
                return subs.First();
            }
            catch (OSDbException e)
            {
                var result = MessageBox.Show(
                    $"Failed to download subtitle: {e.Message}",
                    "Error",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    return await DownloadSubtitle(subId);
                }

                return null;
            }
        }

        private async Task SearchSubtitles(string filename)
        {
            StatusText = "Searching for subtitles...";
            var query = CreateSearchQuery(filename);
            var subs = await SearchSubtitles(query.ToArray());

            subtitleGrid.Subtitles = Mapper.Map<Subtitle[]>(subs)
                .OrderBy(s => s.Language)
                .ThenBy(GetMatchMethodSortOrder)
                .ThenByDescending(s => s.IsFeatured)
                .ThenByDescending(s => s.Rating)
                .ThenByDescending(s => s.DownloadCount);

            StatusText = $"Search returned {subs.Count()} subtitles.";
        }

        private IEnumerable<SearchQuery> CreateSearchQuery(string filename)
        {
            var fileInfo = new FileInfo(filename);
            var langIds = string.Join(",", Settings.Default.Languages.Cast<string>());

            if (Settings.Default.SearchMethods.HasFlag(SearchMethod.Hash) &&
                !string.IsNullOrWhiteSpace(hashTextBox.Text))
            {
                yield return new HashSearchQuery
                {
                    LanguageIds = langIds,
                    FileHash = hashTextBox.Text,
                    FileSize = fileInfo.Length
                };
            }

            if (Settings.Default.SearchMethods.HasFlag(SearchMethod.FullText) &&
                !string.IsNullOrWhiteSpace(textSearchTextBox.Text))
            {
                yield return new FullTextSearchQuery
                {
                    LanguageIds = langIds,
                    Query = textSearchTextBox.Text
                };
            }

            if (Settings.Default.SearchMethods.HasFlag(SearchMethod.Imdb) &&
                !string.IsNullOrWhiteSpace(imdbIdTextBox.Text))
            {
                yield return new ImdbSearchQuery
                {
                    LanguageIds = langIds,
                    ImdbId = imdbIdTextBox.Text
                };
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            await InitSession();

            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
            {
                LoadFile(args[1]);
            }
        }

        private async Task InitSession()
        {
            try
            {
                StatusText = "Inititializing session...";
                await osdbClient.InitSessionAsync();
            }
            catch (OSDbException e)
            {
                var result = MessageBox.Show(
                    $"Failed to initialize session: {e.Message}",
                    "Error",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    await InitSession();
                }
                else
                {
                    Application.Exit();
                }
            }

            StatusText = "Session initialized.";
        }

        private void InitFileDialog()
        {
            var types = FileTypes.VideoTypes.Select(t => $"*.{t}");
            var filter = string.Format(
                "Video Files ({0})|{1}|All Files (*.*)|*.*",
                string.Join(", ", types),
                string.Join(";", types));

            fileDialog = new OpenFileDialog { Filter = filter };
        }

        private void InitSearchMethods()
        {
            searchMethodsMenuItem.DropDownItems.Clear();
            AppendSearchMethod(searchMethodsMenuItem, SearchMethod.Hash, "File hash");
            AppendSearchMethod(searchMethodsMenuItem, SearchMethod.Imdb, "IMDb ID");
            AppendSearchMethod(searchMethodsMenuItem, SearchMethod.FullText, "Full-text search");
            searchMethodsMenuItem.DropDown.Closing += ToolStripDropDownClosing;
        }

        private void AppendSearchMethod(ToolStripDropDownItem menuItem, SearchMethod value, string text)
        {
            var isChecked = Settings.Default.SearchMethods.HasFlag(value);
            var item = new ToolStripMenuItem
            {
                CheckState = isChecked ? CheckState.Checked : CheckState.Unchecked,
                Text = text,
                Tag = value,
                CheckOnClick = true
            };

            menuItem.DropDownItems.Add(item);
            item.CheckedChanged += SearchMethodCheckChanged;
        }

        private void SetSearchMethodStates()
        {
            hashTextBox.Enabled = fileNameTextBox.Enabled && Settings.Default.SearchMethods.HasFlag(SearchMethod.Hash);
            textSearchTextBox.Enabled = fileNameTextBox.Enabled && Settings.Default.SearchMethods.HasFlag(SearchMethod.FullText);
            imdbIdTextBox.Enabled = fileNameTextBox.Enabled && Settings.Default.SearchMethods.HasFlag(SearchMethod.Imdb);
        }

        private void ToolStripDropDownClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            // Prevent dropdown from closing after checking a dropdown menu item
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }

        private void SearchMethodCheckChanged(object sender, EventArgs eventArgs)
        {
            var item = (ToolStripMenuItem)sender;
            var method = (SearchMethod)item.Tag;

            if (item.Checked)
            {
                Settings.Default.SearchMethods = Settings.Default.SearchMethods | method;
            }
            else
            {
                Settings.Default.SearchMethods = Settings.Default.SearchMethods & ~method;
            }

            Settings.Default.Save();
            SetSearchMethodStates();
        }

        private void OpenMenuItemClick(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadFile(fileDialog.FileName);
            }
        }

        private async void DownloadButtonClick(object sender, EventArgs e)
        {
            var sub = subtitleGrid.SelectedSubtitle;

            if (sub == null)
            {
                return;
            }

            StatusText = "Downloading subtitle...";
            var file = await DownloadSubtitle(sub.Id);

            if (file == null)
            {
                StatusText = string.Empty;
                return;
            }

            var data = Convert.FromBase64String(file.Base64Data);
            var subFilePath = Path.ChangeExtension(fileNameTextBox.Text, sub.FileFormat);

            SaveSubtitle(subFilePath, Gzip.Decompress(data));
        }

        private void SaveSubtitle(string path, byte[] data)
        {
            try
            {
                File.WriteAllBytes(path, data);
                StatusText = $@"Saved subtitle to ""{path}"".";
            }
            catch (IOException e)
            {
                var result = MessageBox.Show(
                    $"Failed to save subtitle: {e.Message}",
                    "Error",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    SaveSubtitle(path, data);
                }
                else
                {
                    StatusText = "Download cancelled.";
                }
            }
        }

        private void HandleSubtitleSelectionChanged(object sender, EventArgs e)
        {
            downloadButton.Enabled = subtitleGrid.SelectedSubtitle != null;
        }

        private static int GetMatchMethodSortOrder(Subtitle sub)
        {
            switch (sub.MatchMethod)
            {
                case SearchMethod.Hash:
                    return 0;
                case SearchMethod.Imdb:
                    return 1;
                case SearchMethod.FullText:
                    return 2;
                default:
                    return int.MaxValue;
            }
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            await SearchSubtitles(fileNameTextBox.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void langsMenuItem_Click(object sender, EventArgs e)
        {
            var form = new LanguagesForm();
            form.ShowDialog(this);
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm(osdbClient, githubClient);
            form.ShowDialog(this);
        }

        private void HandleDragEnter(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (files != null &&
                files.Length == 1 &&
                File.Exists(files[0]) &&
                FileTypes.VideoTypes.Contains(Path.GetExtension(files[0]).TrimStart('.')))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void HandleDragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadFile(files[0]);
        }
    }
}
