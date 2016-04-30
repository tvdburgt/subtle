namespace Subtle.Gui.Controls
{
    partial class SubtitleGrid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.FeaturedColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.HearingImpairedColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.SearchMethodColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LanguageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploaderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DownloadsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FeaturedColumn,
            this.HearingImpairedColumn,
            this.SearchMethodColumn,
            this.NameColumn,
            this.LanguageColumn,
            this.UploaderColumn,
            this.UploadedColumn,
            this.DownloadsColumn,
            this.RatingColumn});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(797, 344);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.HandleCellDoubleClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.HandleCellFormatting);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.HandleSelectionChanged);
            // 
            // FeaturedColumn
            // 
            this.FeaturedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = null;
            this.FeaturedColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.FeaturedColumn.FillWeight = 5F;
            this.FeaturedColumn.HeaderText = "";
            this.FeaturedColumn.MinimumWidth = 25;
            this.FeaturedColumn.Name = "FeaturedColumn";
            this.FeaturedColumn.ReadOnly = true;
            this.FeaturedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FeaturedColumn.Width = 25;
            // 
            // HearingImpairedColumn
            // 
            this.HearingImpairedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = null;
            this.HearingImpairedColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.HearingImpairedColumn.FillWeight = 5F;
            this.HearingImpairedColumn.HeaderText = "";
            this.HearingImpairedColumn.MinimumWidth = 25;
            this.HearingImpairedColumn.Name = "HearingImpairedColumn";
            this.HearingImpairedColumn.ReadOnly = true;
            this.HearingImpairedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HearingImpairedColumn.Width = 25;
            // 
            // SearchMethodColumn
            // 
            this.SearchMethodColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.NullValue = null;
            this.SearchMethodColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.SearchMethodColumn.FillWeight = 5F;
            this.SearchMethodColumn.HeaderText = "";
            this.SearchMethodColumn.MinimumWidth = 25;
            this.SearchMethodColumn.Name = "SearchMethodColumn";
            this.SearchMethodColumn.ReadOnly = true;
            this.SearchMethodColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SearchMethodColumn.Width = 25;
            // 
            // NameColumn
            // 
            this.NameColumn.DataPropertyName = "FileName";
            this.NameColumn.FillWeight = 90F;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // LanguageColumn
            // 
            this.LanguageColumn.DataPropertyName = "Language";
            this.LanguageColumn.FillWeight = 23F;
            this.LanguageColumn.HeaderText = "Language";
            this.LanguageColumn.Name = "LanguageColumn";
            this.LanguageColumn.ReadOnly = true;
            // 
            // UploaderColumn
            // 
            this.UploaderColumn.DataPropertyName = "UploaderName";
            this.UploaderColumn.FillWeight = 25F;
            this.UploaderColumn.HeaderText = "Uploader";
            this.UploaderColumn.Name = "UploaderColumn";
            this.UploaderColumn.ReadOnly = true;
            // 
            // UploadedColumn
            // 
            this.UploadedColumn.DataPropertyName = "UploadDate";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.UploadedColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.UploadedColumn.FillWeight = 22F;
            this.UploadedColumn.HeaderText = "Uploaded";
            this.UploadedColumn.Name = "UploadedColumn";
            this.UploadedColumn.ReadOnly = true;
            // 
            // DownloadsColumn
            // 
            this.DownloadsColumn.DataPropertyName = "DownloadCount";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.DownloadsColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.DownloadsColumn.FillWeight = 20F;
            this.DownloadsColumn.HeaderText = "Downloads";
            this.DownloadsColumn.Name = "DownloadsColumn";
            this.DownloadsColumn.ReadOnly = true;
            // 
            // RatingColumn
            // 
            this.RatingColumn.DataPropertyName = "Rating";
            dataGridViewCellStyle6.NullValue = "-";
            this.RatingColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.RatingColumn.FillWeight = 11.12546F;
            this.RatingColumn.HeaderText = "Rating";
            this.RatingColumn.Name = "RatingColumn";
            this.RatingColumn.ReadOnly = true;
            // 
            // SubtitleGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Name = "SubtitleGrid";
            this.Size = new System.Drawing.Size(797, 344);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewImageColumn FeaturedColumn;
        private System.Windows.Forms.DataGridViewImageColumn HearingImpairedColumn;
        private System.Windows.Forms.DataGridViewImageColumn SearchMethodColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LanguageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploaderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DownloadsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatingColumn;
    }
}
