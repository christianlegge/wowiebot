namespace wowiebot
{
    partial class SongRequestForm
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
            this.autoplayCheckBox = new System.Windows.Forms.CheckBox();
            this.playNextButton = new System.Windows.Forms.Button();
            this.songRequestQueueControl1 = new wowiebot.SongRequestQueueControl();
            this.SuspendLayout();
            // 
            // autoplayCheckBox
            // 
            this.autoplayCheckBox.AutoSize = true;
            this.autoplayCheckBox.Checked = true;
            this.autoplayCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoplayCheckBox.Location = new System.Drawing.Point(50, 289);
            this.autoplayCheckBox.Name = "autoplayCheckBox";
            this.autoplayCheckBox.Size = new System.Drawing.Size(67, 17);
            this.autoplayCheckBox.TabIndex = 3;
            this.autoplayCheckBox.Text = "Autoplay";
            this.autoplayCheckBox.UseVisualStyleBackColor = true;
            // 
            // playNextButton
            // 
            this.playNextButton.Location = new System.Drawing.Point(50, 260);
            this.playNextButton.Name = "playNextButton";
            this.playNextButton.Size = new System.Drawing.Size(118, 23);
            this.playNextButton.TabIndex = 4;
            this.playNextButton.Text = "Play Next/Skip";
            this.playNextButton.UseVisualStyleBackColor = true;
            this.playNextButton.Click += new System.EventHandler(this.playNextButton_Click);
            // 
            // songRequestQueueControl1
            // 
            this.songRequestQueueControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songRequestQueueControl1.AutoScroll = true;
            this.songRequestQueueControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.songRequestQueueControl1.Location = new System.Drawing.Point(445, 12);
            this.songRequestQueueControl1.Name = "songRequestQueueControl1";
            this.songRequestQueueControl1.Size = new System.Drawing.Size(596, 326);
            this.songRequestQueueControl1.TabIndex = 0;
            // 
            // SongRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 350);
            this.Controls.Add(this.playNextButton);
            this.Controls.Add(this.autoplayCheckBox);
            this.Controls.Add(this.songRequestQueueControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SongRequestForm";
            this.Text = "Song Requests";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SongRequestQueueControl songRequestQueueControl1;
        private System.Windows.Forms.CheckBox autoplayCheckBox;
        private System.Windows.Forms.Button playNextButton;
    }
}