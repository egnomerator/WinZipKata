namespace WinZipKata
{
    partial class WinZipUI
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
            this.ParentPathInput = new System.Windows.Forms.TextBox();
            this.ParentPathLabel = new System.Windows.Forms.Label();
            this.SubFoldersListing = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ParentPathInput
            // 
            this.ParentPathInput.Location = new System.Drawing.Point(128, 76);
            this.ParentPathInput.Name = "ParentPathInput";
            this.ParentPathInput.Size = new System.Drawing.Size(225, 20);
            this.ParentPathInput.TabIndex = 0;
            // 
            // ParentPathLabel
            // 
            this.ParentPathLabel.AutoSize = true;
            this.ParentPathLabel.Location = new System.Drawing.Point(54, 79);
            this.ParentPathLabel.Name = "ParentPathLabel";
            this.ParentPathLabel.Size = new System.Drawing.Size(66, 13);
            this.ParentPathLabel.TabIndex = 1;
            this.ParentPathLabel.Text = "Parent Path:";
            // 
            // SubFoldersListing
            // 
            this.SubFoldersListing.FormattingEnabled = true;
            this.SubFoldersListing.Location = new System.Drawing.Point(459, 12);
            this.SubFoldersListing.Name = "SubFoldersListing";
            this.SubFoldersListing.Size = new System.Drawing.Size(329, 420);
            this.SubFoldersListing.TabIndex = 2;
            // 
            // WinZipUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SubFoldersListing);
            this.Controls.Add(this.ParentPathLabel);
            this.Controls.Add(this.ParentPathInput);
            this.Name = "WinZipUI";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ParentPathInput;
        private System.Windows.Forms.Label ParentPathLabel;
        private System.Windows.Forms.ListBox SubFoldersListing;
    }
}

