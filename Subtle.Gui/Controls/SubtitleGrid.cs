using Subtle.Gui.Properties;
using Subtle.Gui.SortableBindingList;
using Subtle.Model.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Subtle.Gui.Controls
{
    public partial class SubtitleGrid : UserControl
    {
        public event EventHandler SelectionChanged;

        public SubtitleGrid()
        {
            InitializeComponent();

            dataGridView.AutoGenerateColumns = false;

            // Enable double buffering
            PropertyInfo pi = dataGridView.GetType().GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dataGridView, true, null);
        }

        public IEnumerable<Subtitle> Subtitles
        {
            set
            {
                dataGridView.DataSource = new SortableBindingList<Subtitle>(value);
            }
            get
            {
                return dataGridView.DataSource as IEnumerable<Subtitle>;
            }
        }

        public Subtitle SelectedSubtitle
        {
            get
            {
                if (dataGridView.SelectedRows.Count == 0)
                {
                    return null;
                }

                return dataGridView.SelectedRows[0]?.DataBoundItem as Subtitle;
            }
        }

        private void HandleCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var sub = dataGridView.Rows[e.RowIndex].DataBoundItem as Subtitle;
            var column = dataGridView.Columns[e.ColumnIndex];
            var cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (sub == null)
            {
                return;
            }

            if (column.Name == FeaturedColumn.Name && sub.IsFeatured)
            {
                e.Value = Resources.FeaturedIcon;
                cell.ToolTipText = "Featured";
            }

            if (column.Name == HearingImpairedColumn.Name && sub.IsHearingImpaired)
            {
                e.Value = Resources.HearingImpairedIcon;
                cell.ToolTipText = "Hearing impaired";
            }

            if (column.Name == SearchMethodColumn.Name)
            {
                FormatSearchMethodColumn(sub, cell, e);
            }
        }

        private void HandleCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var sub = dataGridView.Rows[e.RowIndex]?.DataBoundItem as Subtitle;
            if (sub != null)
            {
                System.Diagnostics.Process.Start(sub.Url);
            }
        }

        private static void FormatSearchMethodColumn(Subtitle sub, DataGridViewCell cell, DataGridViewCellFormattingEventArgs e)
        {
            switch (sub.MatchMethod)
            {
                case SearchMethod.Hash:
                    e.Value = Resources.HashIcon;
                    cell.ToolTipText = "Matched by file hash";
                    break;
                case SearchMethod.FullText:
                    e.Value = Resources.TextSearchIcon;
                    cell.ToolTipText = "Matched by full-text search";
                    break;
                case SearchMethod.Imdb:
                    e.Value = Resources.ImdbIcon;
                    cell.ToolTipText = "Matched by IMDb ID";
                    break;
            }
        }

        private void HandleSelectionChanged(object sender, EventArgs e)
        {
            SelectionChanged?.Invoke(this, e);
        }
    }
}
