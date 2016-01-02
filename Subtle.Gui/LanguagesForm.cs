using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using Subtle.Gui.Properties;
using Subtle.Model;

namespace Subtle.Gui
{
    public partial class LanguagesForm : Form
    {
        private StringCollection UserLanguages => Settings.Default.Languages;

        public LanguagesForm()
        {
            InitializeComponent();
            InitLanguages();
        }

        private void InitLanguages()
        {
            languagesCheckedListBox.DataSource = OSDbConfig.Languages;
            languagesCheckedListBox.DisplayMember = "Name";

            var langs = OSDbConfig.Languages.ToList();

            foreach (var lang in UserLanguages)
            {
                var i = langs.FindIndex(l => l.Iso6392.Equals(lang));
                if (i >= 0)
                {
                    languagesCheckedListBox.SetItemChecked(i, true);
                }
            }
        }

        private void languagesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var lang = OSDbConfig.Languages[e.Index];
            switch (e.NewValue)
            {
                case CheckState.Unchecked:
                    if (UserLanguages.Contains(lang.Iso6392))
                    {
                        UserLanguages.Remove(lang.Iso6392);
                        Settings.Default.Save();
                    }
                    break;
                case CheckState.Checked:
                    if (!UserLanguages.Contains(lang.Iso6392))
                    {
                        UserLanguages.Add(lang.Iso6392);
                        Settings.Default.Save();
                    }
                    break;
            }

            var langs = UserLanguages
                .Cast<string>()
                .Select(code => OSDbConfig.Languages.FirstOrDefault(l => l.Iso6392.Equals(code)))
                .Where(l => l != null)
                .OrderBy(l => l.Name);

            languagesLabel.Text = $@"Selected languages: {string.Join(", ", langs.Select(l => l.Name))}";
        }

        private void LanguagesForm_Resize(object sender, System.EventArgs e)
        {
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
