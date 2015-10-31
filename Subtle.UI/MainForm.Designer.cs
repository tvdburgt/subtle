namespace Subtle.UI
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileHashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iMDbIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fulltextSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.fileTable = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.hashTextBox = new System.Windows.Forms.TextBox();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.subtitleGrid = new System.Windows.Forms.DataGridView();
            this.FeaturedColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.SearchMethodColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.languageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.searchButton = new System.Windows.Forms.Button();
            this.imdbIdTextBox = new Subtle.UI.Controls.ImdbTextBox();
            this.menuStrip1.SuspendLayout();
            this.fileTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subtitleGrid)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.languagesToolStripMenuItem,
            this.searchMethodsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            this.languagesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.languagesToolStripMenuItem.Text = "Languages";
            // 
            // searchMethodsToolStripMenuItem
            // 
            this.searchMethodsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileHashToolStripMenuItem,
            this.iMDbIDToolStripMenuItem,
            this.fulltextSearchToolStripMenuItem});
            this.searchMethodsToolStripMenuItem.Name = "searchMethodsToolStripMenuItem";
            this.searchMethodsToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.searchMethodsToolStripMenuItem.Text = "Search Methods";
            // 
            // fileHashToolStripMenuItem
            // 
            this.fileHashToolStripMenuItem.CheckOnClick = true;
            this.fileHashToolStripMenuItem.Name = "fileHashToolStripMenuItem";
            this.fileHashToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.fileHashToolStripMenuItem.Text = "File hash";
            // 
            // iMDbIDToolStripMenuItem
            // 
            this.iMDbIDToolStripMenuItem.CheckOnClick = true;
            this.iMDbIDToolStripMenuItem.Name = "iMDbIDToolStripMenuItem";
            this.iMDbIDToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.iMDbIDToolStripMenuItem.Text = "IMDb ID";
            // 
            // fulltextSearchToolStripMenuItem
            // 
            this.fulltextSearchToolStripMenuItem.CheckOnClick = true;
            this.fulltextSearchToolStripMenuItem.Name = "fulltextSearchToolStripMenuItem";
            this.fulltextSearchToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.fulltextSearchToolStripMenuItem.Text = "Full-text search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 1;
            // 
            // fileTable
            // 
            this.fileTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTable.ColumnCount = 2;
            this.fileTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.27523F));
            this.fileTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.72477F));
            this.fileTable.Controls.Add(this.label5, 0, 3);
            this.fileTable.Controls.Add(this.hashTextBox, 1, 1);
            this.fileTable.Controls.Add(this.fileTextBox, 1, 0);
            this.fileTable.Controls.Add(this.label3, 0, 0);
            this.fileTable.Controls.Add(this.label4, 0, 1);
            this.fileTable.Controls.Add(this.queryTextBox, 1, 2);
            this.fileTable.Controls.Add(this.label2, 0, 2);
            this.fileTable.Controls.Add(this.imdbIdTextBox, 1, 3);
            this.fileTable.Location = new System.Drawing.Point(12, 31);
            this.fileTable.Name = "fileTable";
            this.fileTable.RowCount = 4;
            this.fileTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.fileTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.fileTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.fileTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.fileTable.Size = new System.Drawing.Size(960, 123);
            this.fileTable.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "IMDb ID:";
            // 
            // hashTextBox
            // 
            this.hashTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hashTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.hashTextBox.Location = new System.Drawing.Point(101, 33);
            this.hashTextBox.Name = "hashTextBox";
            this.hashTextBox.ReadOnly = true;
            this.hashTextBox.Size = new System.Drawing.Size(129, 23);
            this.hashTextBox.TabIndex = 7;
            // 
            // fileTextBox
            // 
            this.fileTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fileTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.fileTextBox.Location = new System.Drawing.Point(101, 3);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(690, 23);
            this.fileTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "File:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hash:";
            // 
            // queryTextBox
            // 
            this.queryTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.queryTextBox.Enabled = false;
            this.queryTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.queryTextBox.Location = new System.Drawing.Point(101, 63);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(690, 23);
            this.queryTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Query:";
            // 
            // subtitleGrid
            // 
            this.subtitleGrid.AllowUserToAddRows = false;
            this.subtitleGrid.AllowUserToDeleteRows = false;
            this.subtitleGrid.AllowUserToResizeColumns = false;
            this.subtitleGrid.AllowUserToResizeRows = false;
            this.subtitleGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.subtitleGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.subtitleGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.subtitleGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.subtitleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subtitleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FeaturedColumn,
            this.SearchMethodColumn,
            this.nameColumn,
            this.languageColumn,
            this.Column1,
            this.Column3,
            this.Column2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.subtitleGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.subtitleGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.subtitleGrid.Location = new System.Drawing.Point(12, 160);
            this.subtitleGrid.MultiSelect = false;
            this.subtitleGrid.Name = "subtitleGrid";
            this.subtitleGrid.ReadOnly = true;
            this.subtitleGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.subtitleGrid.RowHeadersVisible = false;
            this.subtitleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subtitleGrid.Size = new System.Drawing.Size(960, 340);
            this.subtitleGrid.TabIndex = 4;
            this.subtitleGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.SubtitleGridCellFormatting);
            this.subtitleGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SubtitleGridCellMouseDoubleClick);
            this.subtitleGrid.SelectionChanged += new System.EventHandler(this.SubtitleGridSelectionChanged);
            // 
            // FeaturedColumn
            // 
            this.FeaturedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = null;
            this.FeaturedColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.FeaturedColumn.FillWeight = 26.55415F;
            this.FeaturedColumn.HeaderText = "";
            this.FeaturedColumn.MinimumWidth = 25;
            this.FeaturedColumn.Name = "FeaturedColumn";
            this.FeaturedColumn.ReadOnly = true;
            this.FeaturedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FeaturedColumn.ToolTipText = "Featured subtitle";
            this.FeaturedColumn.Width = 25;
            // 
            // SearchMethodColumn
            // 
            this.SearchMethodColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.NullValue = null;
            this.SearchMethodColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.SearchMethodColumn.FillWeight = 5F;
            this.SearchMethodColumn.HeaderText = "";
            this.SearchMethodColumn.MinimumWidth = 25;
            this.SearchMethodColumn.Name = "SearchMethodColumn";
            this.SearchMethodColumn.ReadOnly = true;
            this.SearchMethodColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SearchMethodColumn.Width = 25;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "FileName";
            this.nameColumn.FillWeight = 117.9331F;
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // languageColumn
            // 
            this.languageColumn.DataPropertyName = "Language";
            this.languageColumn.FillWeight = 39.31104F;
            this.languageColumn.HeaderText = "Language";
            this.languageColumn.Name = "languageColumn";
            this.languageColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "UploadDate";
            this.Column1.FillWeight = 52.41473F;
            this.Column1.HeaderText = "Uploaded";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DownloadCount";
            this.Column3.FillWeight = 26.20736F;
            this.Column3.HeaderText = "Downloads";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Rating";
            this.Column2.FillWeight = 13.10368F;
            this.Column2.HeaderText = "Rating";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.Enabled = false;
            this.downloadButton.Location = new System.Drawing.Point(876, 506);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(96, 30);
            this.downloadButton.TabIndex = 5;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.DownloadButtonClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStrip});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 556);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 5);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStrip
            // 
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(0, 0);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(789, 506);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(81, 30);
            this.searchButton.TabIndex = 9;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // imdbIdTextBox
            // 
            this.imdbIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.imdbIdTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.imdbIdTextBox.Location = new System.Drawing.Point(101, 95);
            this.imdbIdTextBox.MaxLength = 7;
            this.imdbIdTextBox.Name = "imdbIdTextBox";
            this.imdbIdTextBox.Size = new System.Drawing.Size(129, 23);
            this.imdbIdTextBox.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.subtitleGrid);
            this.Controls.Add(this.fileTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = global::Subtle.UI.Properties.Resources.Subtle;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.Text = "Subtle";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.fileTable.ResumeLayout(false);
            this.fileTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subtitleGrid)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel fileTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.DataGridView subtitleGrid;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.ToolStripMenuItem languagesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusStrip;
        private System.Windows.Forms.TextBox hashTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewImageColumn FeaturedColumn;
        private System.Windows.Forms.DataGridViewImageColumn SearchMethodColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn languageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripMenuItem searchMethodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileHashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iMDbIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fulltextSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.ImdbTextBox imdbIdTextBox;
    }
}

