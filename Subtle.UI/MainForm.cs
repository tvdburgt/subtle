using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using Subtle.Model;
using Subtle.Model.Helpers;
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
            var fileInfo = new FileInfo(filename);

            if (!fileInfo.Exists)
            {
                return;
            }

            var hash = Crypto.HashFile(filename);

            fileTextBox.Text = filename;
            hashTextBox.Text = Crypto.BinaryToHex(hash);
            StatusText = "Searching...";

            var subs = await client.SearchSubtitlesAsync(
                hash, fileInfo.Length, Settings.Default.Languages.Cast<string>());

            subtitleBindingSource.DataSource = Mapper.Map<SubtitleViewModel[]>(subs)
                .OrderBy(s => s.Language)
                .ThenByDescending(s => s.IsFeatured)
                .ThenByDescending(s => s.Rating)
                .ThenByDescending(s => s.DownloadCount);

            subtitleBindingSource.ResetBindings(false);
            StatusText = $"Search returned {subs.Count()} subtitles.";
        }

        #region Initialization

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await client.Login();

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
                    Checked = Settings.Default.Languages.Contains(lang.Id),
                    Tag = lang
                };

                languagesToolStripMenuItem.DropDownItems.Add(item);
                item.CheckedChanged += LanguageCheckChanged;
            }

            languagesToolStripMenuItem.DropDown.Closing += LanguagesDropDownClosing;
        }

        #endregion

        #region Event handlers

        private void LanguagesDropDownClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            // Prevent dropdown from closing after checking a language item
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked ||
                e.CloseReason == ToolStripDropDownCloseReason.AppFocusChange)
            {
                e.Cancel = true;
            }
        }

        private void LanguageCheckChanged(object sender, EventArgs eventArgs)
        {
            var item = (ToolStripMenuItem)sender;
            var lang = (Language)item.Tag;

            if (item.Checked)
            {
                Settings.Default.Languages.Add(lang.Id);
            }
            else
            {
                Settings.Default.Languages.Remove(lang.Id);
            }

            Settings.Default.Save();
        }

        private void OpenMenuItemClick(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
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

            StatusText = $"Saved subtitle to {subFilePath}.";
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
            if (subtitleGrid.Columns[e.ColumnIndex].Name != "FeaturedColumn")
            {
                return;
            }

            var sub = subtitleGrid.Rows[e.RowIndex].DataBoundItem as SubtitleViewModel;

            if (sub == null)
            {
                return;
            }

            if (sub.IsFeatured)
            {
                e.Value = Resources.Featured;
                subtitleGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Featured";
            }
            else
            {
                e.Value = null;
            }
        }

        #endregion
    }
}
