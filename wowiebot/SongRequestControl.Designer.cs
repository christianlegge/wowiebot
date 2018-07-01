namespace wowiebot
{
    partial class SongRequestControl
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
            this.thumbPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.uploaderLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.viewsLabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.requestedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.thumbPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // thumbPictureBox
            // 
            this.thumbPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.thumbPictureBox.Location = new System.Drawing.Point(4, 4);
            this.thumbPictureBox.Name = "thumbPictureBox";
            this.thumbPictureBox.Size = new System.Drawing.Size(144, 121);
            this.thumbPictureBox.TabIndex = 0;
            this.thumbPictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(154, 4);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(23, 13);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "title";
            // 
            // uploaderLabel
            // 
            this.uploaderLabel.AutoSize = true;
            this.uploaderLabel.Location = new System.Drawing.Point(154, 21);
            this.uploaderLabel.Name = "uploaderLabel";
            this.uploaderLabel.Size = new System.Drawing.Size(48, 13);
            this.uploaderLabel.TabIndex = 2;
            this.uploaderLabel.Text = "uploader";
            // 
            // durationLabel
            // 
            this.durationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(454, 4);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(45, 13);
            this.durationLabel.TabIndex = 3;
            this.durationLabel.Text = "duration";
            // 
            // viewsLabel
            // 
            this.viewsLabel.AutoSize = true;
            this.viewsLabel.Location = new System.Drawing.Point(465, 21);
            this.viewsLabel.Name = "viewsLabel";
            this.viewsLabel.Size = new System.Drawing.Size(34, 13);
            this.viewsLabel.TabIndex = 4;
            this.viewsLabel.Text = "views";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(154, 43);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // requestedLabel
            // 
            this.requestedLabel.AutoSize = true;
            this.requestedLabel.Location = new System.Drawing.Point(154, 73);
            this.requestedLabel.Name = "requestedLabel";
            this.requestedLabel.Size = new System.Drawing.Size(79, 13);
            this.requestedLabel.TabIndex = 6;
            this.requestedLabel.Text = "Requested by: ";
            // 
            // SongRequestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.requestedLabel);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.viewsLabel);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.uploaderLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.thumbPictureBox);
            this.Name = "SongRequestControl";
            this.Size = new System.Drawing.Size(554, 128);
            ((System.ComponentModel.ISupportInitialize)(this.thumbPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox thumbPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label uploaderLabel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label viewsLabel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label requestedLabel;
    }
}
