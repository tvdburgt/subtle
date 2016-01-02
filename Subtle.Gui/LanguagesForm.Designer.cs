namespace Subtle.Gui
{
    partial class LanguagesForm
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
            this.languagesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.languagesLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // languagesCheckedListBox
            // 
            this.languagesCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.languagesCheckedListBox.CheckOnClick = true;
            this.languagesCheckedListBox.FormattingEnabled = true;
            this.languagesCheckedListBox.Location = new System.Drawing.Point(12, 34);
            this.languagesCheckedListBox.Name = "languagesCheckedListBox";
            this.languagesCheckedListBox.Size = new System.Drawing.Size(285, 259);
            this.languagesCheckedListBox.TabIndex = 0;
            this.languagesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.languagesCheckedListBox_ItemCheck);
            // 
            // languagesLabel
            // 
            this.languagesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.languagesLabel.AutoEllipsis = true;
            this.languagesLabel.Location = new System.Drawing.Point(12, 9);
            this.languagesLabel.Name = "languagesLabel";
            this.languagesLabel.Size = new System.Drawing.Size(285, 13);
            this.languagesLabel.TabIndex = 1;
            this.languagesLabel.Text = "Selected languages:";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(222, 307);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // LanguagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(309, 342);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.languagesLabel);
            this.Controls.Add(this.languagesCheckedListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::Subtle.Gui.Properties.Resources.Subtle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LanguagesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Subtitle languages";
            this.Resize += new System.EventHandler(this.LanguagesForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox languagesCheckedListBox;
        private System.Windows.Forms.Label languagesLabel;
        private System.Windows.Forms.Button okButton;
    }
}