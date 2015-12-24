using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using Subtle.Gui.ViewModels;
using Subtle.Model;
using Subtle.Model.Helpers;
using Subtle.Model.Requests;
using Subtle.Model.Responses;

namespace Subtle.Gui
{
    public partial class MainForm : Form
    {
        private readonly OSDbClient client;
        private OpenFileDialog fileDialog;
        private BindingSource subtitleBindingSource;

        public MainForm()
        {
            InitializeComponent();
            InitLanguages();
            InitSearchMethods();
            InitFileDialog();
            InitSubtitleGrid();

            WindowTitle = $"{Application.ProductName} {Application.ProductVersion}";

#if DEBUG
            client = new OSDbClient(OSDbClient.TestUserAgent);
            WindowTitle += " (debug)";
#else
            client = new OSDbClient();
#endif
        }

        private string StatusText
        {
            set { statusStrip.Text = value; }
        }

        private string WindowTitle
        {
            get { return Text; }
            set { Text = value; }
        }

        private void LoadFile(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }

            var hash = Crypto.HashFile(filename);
            fileNameTextBox.Text = filename;
            hashTextBox.Text = Crypto.BinaryToHex(hash);
            imdbIdTextBox.Text = ImdbHelper.GetImdbId(filename);
            textSearchTextBox.Text = Path.GetFileNameWithoutExtension(filename);
            searchButton.Enabled = true;

            SetSearchMethodStates();
        }

        private async Task<SubtitleSearchResultCollection> SearchSubtitles(SearchQuery[] query)
        {
            var subs = new SubtitleSearchResultCollection();

            try
            {
                subs = await client.SearchSubtitlesAsync(query);
            }
            catch (OSDbException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (WebException e)
            {
                var text = $"Subtitle search failed: {e.Message}";
                var result = MessageBox.Show(
                    text, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

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
                var subs = await client.DownloadSubtitlesAsync(subId);
                return subs.First();
            }
            catch (WebException e)
            {
                var text = $"Failed to download subtitle: {e.Message}";
                var result = MessageBox.Show(
                    text, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    return await DownloadSubtitle(subId);
                }

                return null;
            }
        }

        private async void SearchSubtitles(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }

            StatusText = "Searching...";
            var query = CreateSearchQuery(filename);
            var subs = await SearchSubtitles(query.ToArray());

            subtitleBindingSource.DataSource = Mapper.Map<SubtitleViewModel[]>(subs)
                        .OrderBy(s => s.Language)
                        .ThenBy(GetMatchMethodSortOrder)
                        .ThenByDescending(s => s.IsFeatured)
                        .ThenByDescending(s => s.Rating)
                        .ThenByDescending(s => s.DownloadCount)
                        .ToList();

            subtitleBindingSource.ResetBindings(false);
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

        #region Initialization

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            StatusText = "Inititializing session...";
            await InitSession();
            StatusText = "Session initialized.";

            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
            {
                LoadFile(args[1]);
                SearchSubtitles(args[1]);
            }
        }

        private async Task InitSession()
        {
            try
            {
                await client.InitSessionAsync();
            }
            catch (WebException we)
            {
                var text = $"Failed to initialize session: {we.Message}";
                var result = MessageBox.Show(
                    text, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    await InitSession();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void InitSubtitleGrid()
        {
            subtitleBindingSource = new BindingSource();
            subtitleGrid.AutoGenerateColumns = false;
            subtitleGrid.DataSource = subtitleBindingSource;
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

        private void InitLanguages()
        {
            languagesToolStripMenuItem.DropDownItems.Clear();

            foreach (var lang in OSDbConfig.Languages)
            {
                var item = new ToolStripMenuItem
                {
                    Text = lang.Name,
                    CheckState = CheckState.Checked,
                    CheckOnClick = true,
                    Checked = Settings.Default.Languages.Contains(lang.Iso6392),
                    Tag = lang
                };

                languagesToolStripMenuItem.DropDownItems.Add(item);
                item.CheckedChanged += LanguageCheckChanged;
            }

            languagesToolStripMenuItem.DropDown.Closing += ToolStripDropDownClosing;
        }

        private void InitSearchMethods()
        {
            searchMethodsToolStripMenuItem.DropDownItems.Clear();

            AppendSearchMethod(SearchMethod.Hash, "File Hash");
            AppendSearchMethod(SearchMethod.Imdb, "IMDb ID");
            AppendSearchMethod(SearchMethod.FullText, "Full-Text Search");

            searchMethodsToolStripMenuItem.DropDown.Closing += ToolStripDropDownClosing;
        }

        private void AppendSearchMethod(SearchMethod value, string text)
        {
            var isChecked = Settings.Default.SearchMethods.HasFlag(value);
            var item = new ToolStripMenuItem
            {
                CheckState = isChecked ? CheckState.Checked : CheckState.Unchecked,
                Text = text,
                Tag = value,
                CheckOnClick = true
            };

            searchMethodsToolStripMenuItem.DropDownItems.Add(item);
            item.CheckedChanged += SearchMethodCheckChanged;
        }

        #endregion

        private void SetSearchMethodStates()
        {
            hashTextBox.Enabled = Settings.Default.SearchMethods.HasFlag(SearchMethod.Hash);
            textSearchTextBox.Enabled = Settings.Default.SearchMethods.HasFlag(SearchMethod.FullText);
            imdbIdTextBox.Enabled = Settings.Default.SearchMethods.HasFlag(SearchMethod.Imdb);
        }

        #region Event handlers

        private void ToolStripDropDownClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            // Prevent dropdown from closing after checking a language item
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

        private void LanguageCheckChanged(object sender, EventArgs eventArgs)
        {
            var item = (ToolStripMenuItem)sender;
            var lang = (Language)item.Tag;

            if (item.Checked)
            {
                Settings.Default.Languages.Add(lang.Iso6392);
            }
            else
            {
                Settings.Default.Languages.Remove(lang.Iso6392);
            }

            Settings.Default.Save();
        }

        private void OpenMenuItemClick(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadFile(fileDialog.FileName);
                SearchSubtitles(fileDialog.FileName);
            }
        }

        private async void DownloadButtonClick(object sender, EventArgs e)
        {
            var sub = subtitleGrid.SelectedRows[0]?.DataBoundItem as SubtitleViewModel;

            if (sub == null)
            {
                return;
            }

            StatusText = "Downloading...";
            var file = await DownloadSubtitle(sub.Id);

            if (file == null)
            {
                StatusText = string.Empty;
                return;
            }

            var data = Convert.FromBase64String(file.Base64Data);
            var subFilePath = Path.ChangeExtension(fileNameTextBox.Text, sub.FileFormat);
            File.WriteAllBytes(subFilePath, Gzip.Decompress(data));

            StatusText = $@"Saved subtitle to ""{subFilePath}"".";
        }

        private void SubtitleGridSelectionChanged(object sender, EventArgs e)
        {
            downloadButton.Enabled = (subtitleGrid.SelectedRows.Count > 0);
        }

        private void SubtitleGridCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var sub = subtitleGrid.SelectedRows[0]?.DataBoundItem as SubtitleViewModel;
            if (sub != null)
            {
                System.Diagnostics.Process.Start(sub.Url);
            }
        }

        private void SubtitleGridCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var sub = subtitleGrid.Rows[e.RowIndex].DataBoundItem as SubtitleViewModel;
            if (sub == null)
            {
                return;
            }

            if (subtitleGrid.Columns[e.ColumnIndex].Name == "FeaturedColumn")
            {
                if (sub.IsFeatured)
                {
                    e.Value = Resources.FeaturedIcon;
                    subtitleGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Featured";
                }
                else
                {
                    e.Value = null;
                }
            }

            if (subtitleGrid.Columns[e.ColumnIndex].Name == "SearchMethodColumn")
            {
                switch (sub.MatchMethod)
                {
                    case SubtitleSearchResult.SearchMethods.Hash:
                        subtitleGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Matched by file hash";
                        e.Value = Resources.HashIcon;
                        break;
                    case SubtitleSearchResult.SearchMethods.FullText:
                        subtitleGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Matched by full-text search";
                        e.Value = Resources.TextSearchIcon;
                        break;
                    case SubtitleSearchResult.SearchMethods.Imdb:
                        subtitleGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Matched IMDb ID";
                        e.Value = Resources.ImdbIcon;
                        break;
                }
            }
        }

        private static int GetMatchMethodSortOrder(SubtitleViewModel sub)
        {
            switch (sub.MatchMethod)
            {
                case SubtitleSearchResult.SearchMethods.Hash:
                    return 0;
                case SubtitleSearchResult.SearchMethods.Imdb:
                    return 1;
                case SubtitleSearchResult.SearchMethods.FullText:
                    return 2;
                default:
                    return int.MaxValue;
            }
        }

        #endregion

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchSubtitles(fileNameTextBox.Text);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
