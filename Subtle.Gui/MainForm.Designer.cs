using Subtle.Gui.Controls;

namespace Subtle.Gui
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMethodsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.fileTable = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.hashTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textSearchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.subtitleGrid = new System.Windows.Forms.DataGridView();
            this.FeaturedColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.HearingImpairedColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.SearchMethodColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.languageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploaderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.searchButton = new System.Windows.Forms.Button();
            this.imdbIdTextBox = new Subtle.Gui.Controls.ImdbTextBox();
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
            this.prefsMenu,
            this.helpToolStripMenuItem});
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
            this.exitToolStripMenuItem});
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
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // prefsMenu
            // 
            this.prefsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchMethodsMenuItem,
            this.langMenuItem});
            this.prefsMenu.Name = "prefsMenu";
            this.prefsMenu.Size = new System.Drawing.Size(80, 20);
            this.prefsMenu.Text = "Preferences";
            // 
            // searchMethodsMenuItem
            // 
            this.searchMethodsMenuItem.Name = "searchMethodsMenuItem";
            this.searchMethodsMenuItem.Size = new System.Drawing.Size(159, 22);
            this.searchMethodsMenuItem.Text = "Search methods";
            // 
            // langMenuItem
            // 
            this.langMenuItem.Name = "langMenuItem";
            this.langMenuItem.Size = new System.Drawing.Size(159, 22);
            this.langMenuItem.Text = "Languages...";
            this.langMenuItem.Click += new System.EventHandler(this.langsMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
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
            this.fileTable.Controls.Add(this.fileNameTextBox, 1, 0);
            this.fileTable.Controls.Add(this.label3, 0, 0);
            this.fileTable.Controls.Add(this.label4, 0, 1);
            this.fileTable.Controls.Add(this.textSearchTextBox, 1, 2);
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
            this.hashTextBox.Enabled = false;
            this.hashTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.hashTextBox.Location = new System.Drawing.Point(101, 33);
            this.hashTextBox.Name = "hashTextBox";
            this.hashTextBox.ReadOnly = true;
            this.hashTextBox.Size = new System.Drawing.Size(119, 23);
            this.hashTextBox.TabIndex = 7;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fileNameTextBox.Enabled = false;
            this.fileNameTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.fileNameTextBox.Location = new System.Drawing.Point(101, 3);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            this.fileNameTextBox.Size = new System.Drawing.Size(690, 23);
            this.fileNameTextBox.TabIndex = 6;
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
            // textSearchTextBox
            // 
            this.textSearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textSearchTextBox.Enabled = false;
            this.textSearchTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.textSearchTextBox.Location = new System.Drawing.Point(101, 63);
            this.textSearchTextBox.Name = "textSearchTextBox";
            this.textSearchTextBox.Size = new System.Drawing.Size(690, 23);
            this.textSearchTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Text search:";
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
            this.subtitleGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.subtitleGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.subtitleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subtitleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FeaturedColumn,
            this.HearingImpairedColumn,
            this.SearchMethodColumn,
            this.nameColumn,
            this.languageColumn,
            this.UploaderColumn,
            this.UploadedColumn,
            this.Column3,
            this.Column2});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.subtitleGrid.DefaultCellStyle = dataGridViewCellStyle7;
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
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "FileName";
            this.nameColumn.FillWeight = 90F;
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // languageColumn
            // 
            this.languageColumn.DataPropertyName = "Language";
            this.languageColumn.FillWeight = 23F;
            this.languageColumn.HeaderText = "Language";
            this.languageColumn.Name = "languageColumn";
            this.languageColumn.ReadOnly = true;
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
            // Column3
            // 
            this.Column3.DataPropertyName = "DownloadCount";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.FillWeight = 20F;
            this.Column3.HeaderText = "Downloads";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Rating";
            dataGridViewCellStyle6.NullValue = "-";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column2.FillWeight = 11.12546F;
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
            this.imdbIdTextBox.Enabled = false;
            this.imdbIdTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.imdbIdTextBox.Location = new System.Drawing.Point(101, 95);
            this.imdbIdTextBox.MaxLength = 7;
            this.imdbIdTextBox.Name = "imdbIdTextBox";
            this.imdbIdTextBox.Size = new System.Drawing.Size(55, 23);
            this.imdbIdTextBox.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
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
            this.Icon = global::Subtle.Gui.Properties.Resources.Subtle;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(888, 400);
            this.Name = "MainForm";
            this.Text = "Subtle";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.HandleDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
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
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusStrip;
        private System.Windows.Forms.TextBox hashTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textSearchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.ImdbTextBox imdbIdTextBox;
        private System.Windows.Forms.ToolStripMenuItem prefsMenu;
        private System.Windows.Forms.ToolStripMenuItem langMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchMethodsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn FeaturedColumn;
        private System.Windows.Forms.DataGridViewImageColumn HearingImpairedColumn;
        private System.Windows.Forms.DataGridViewImageColumn SearchMethodColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn languageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploaderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

