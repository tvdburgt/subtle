using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using Subtle.Model;
using Subtle.Model.Helpers;
using Subtle.Model.Requests;
using Subtle.Model.Responses;
using Subtle.UI.Properties;
using Subtle.UI.ViewModels;

namespace Subtle.UI
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

            client = new OSDbClient();
        }

        private string StatusText
        {
            set
            {
                statusStrip.Text = value;
            }
        }

        private async void SearchSubtitles(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }

            var fileInfo = new FileInfo(filename);
            var hash = Crypto.HashFile(filename);
            var hashString = Crypto.BinaryToHex(hash);

            fileTextBox.Text = filename;
            hashTextBox.Text = hashString;

            StatusText = "Searching...";

            var langIds = string.Join(",", Settings.Default.Languages.Cast<string>());
            var queries = new List<SearchQuery>();

            queries.Add(new HashSearchQuery
            {
                LanguageIds = langIds,
                FileHash = hashString,
                FileSize = fileInfo.Length
            });

            if (queryTextBox.Enabled && !string.IsNullOrWhiteSpace(queryTextBox.Text))
            {
                queries.Add(new FullTextSearchQuery
                {
                    LanguageIds = langIds,
                    Query = queryTextBox.Text
                });
            }

            if (imdbIdTextBox.Enabled && !string.IsNullOrWhiteSpace(imdbIdTextBox.Text))
            {
                queries.Add(new ImdbSearchQuery
                {
                    LanguageIds = langIds,
                    ImdbId = imdbIdTextBox.Text
                });
            }

            var subs = new SubtitleSearchResultCollection();

            try
            {
                subs = await client.SearchSubtitlesAsync(queries.ToArray());
            }
            catch (Exception e)
            {
                // TODO: concrete exception
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        #region Initialization

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await client.InitSessionAsync();

            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
            {
                SearchSubtitles(args[1]);
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

        private void UpdateSearchMethodInputs()
        {
            queryTextBox.Enabled = Settings.Default.SearchMethods.HasFlag(SearchMethod.FullText);
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
            UpdateSearchMethodInputs();
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
                imdbIdTextBox.Text = ImdbHelper.GetImdbId(fileDialog.FileName);
                queryTextBox.Text = Path.GetFileNameWithoutExtension(fileDialog.FileName);
                UpdateSearchMethodInputs();
                searchButton.Enabled = true;
                SearchSubtitles(fileDialog.FileName);
            }
        }

        private async void DownloadButtonClick(object sender, EventArgs e)
        {
            var sub = subtitleGrid.SelectedRows[0].DataBoundItem as SubtitleViewModel;

            if (sub == null)
            {
                return;
            }

            StatusText = "Downloading...";
            var file = await client.DownloadSubtitleAsync(sub.Id);
            var data = Convert.FromBase64String(file.Base64Data);

            var subFilePath = Path.ChangeExtension(fileDialog.FileName, sub.FileFormat);
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

            var sub = subtitleGrid.SelectedRows[0].DataBoundItem as SubtitleViewModel;

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
                    case SubtitleSearchResult.MatchMethods.Hash:
                        subtitleGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Matched by file hash";
                        e.Value = Resources.HashIcon;
                        break;
                    case SubtitleSearchResult.MatchMethods.FullText:
                        subtitleGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Matched by full-text search";
                        e.Value = Resources.TextSearchIcon;
                        break;
                    case SubtitleSearchResult.MatchMethods.Imdb:
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
                case SubtitleSearchResult.MatchMethods.Hash:
                    return 0;
                case SubtitleSearchResult.MatchMethods.Imdb:
                    return 1;
                case SubtitleSearchResult.MatchMethods.FullText:
                    return 2;
                default:
                    return int.MaxValue;
            }
        }

        #endregion

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchSubtitles(fileDialog.FileName);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
