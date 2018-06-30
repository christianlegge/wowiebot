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
            this.toQueueTextBox = new System.Windows.Forms.TextBox();
            this.queueButton = new System.Windows.Forms.Button();
            this.songRequestQueueControl1 = new wowiebot.SongRequestQueueControl(this);
            this.SuspendLayout();
            // 
            // toQueueTextBox
            // 
            this.toQueueTextBox.Location = new System.Drawing.Point(38, 388);
            this.toQueueTextBox.Name = "toQueueTextBox";
            this.toQueueTextBox.Size = new System.Drawing.Size(318, 20);
            this.toQueueTextBox.TabIndex = 1;
            // 
            // queueButton
            // 
            this.queueButton.Location = new System.Drawing.Point(72, 425);
            this.queueButton.Name = "queueButton";
            this.queueButton.Size = new System.Drawing.Size(75, 23);
            this.queueButton.TabIndex = 2;
            this.queueButton.Text = "Queue";
            this.queueButton.UseVisualStyleBackColor = true;
            this.queueButton.Click += new System.EventHandler(this.queueButton_Click);
            // 
            // songRequestQueueControl1
            // 
            this.songRequestQueueControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songRequestQueueControl1.AutoScroll = true;
            this.songRequestQueueControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.songRequestQueueControl1.Location = new System.Drawing.Point(391, 12);
            this.songRequestQueueControl1.Name = "songRequestQueueControl1";
            this.songRequestQueueControl1.Size = new System.Drawing.Size(574, 505);
            this.songRequestQueueControl1.TabIndex = 0;
            // 
            // SongRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 529);
            this.Controls.Add(this.queueButton);
            this.Controls.Add(this.toQueueTextBox);
            this.Controls.Add(this.songRequestQueueControl1);
            this.Name = "SongRequestForm";
            this.Text = "SongRequestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SongRequestQueueControl songRequestQueueControl1;
        private System.Windows.Forms.TextBox toQueueTextBox;
        private System.Windows.Forms.Button queueButton;
    }
}