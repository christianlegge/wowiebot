namespace wowiebot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.channelTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.loginPopoutButton = new System.Windows.Forms.Button();
            this.useWowieBox = new System.Windows.Forms.CheckBox();
            this.configButton = new System.Windows.Forms.Button();
            this.serverOutTextBox = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.songRequestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // channelTextBox
            // 
            this.channelTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.channelTextBox.Location = new System.Drawing.Point(178, 190);
            this.channelTextBox.MaxLength = 25;
            this.channelTextBox.Name = "channelTextBox";
            this.channelTextBox.Size = new System.Drawing.Size(150, 20);
            this.channelTextBox.TabIndex = 0;
            this.channelTextBox.TextChanged += new System.EventHandler(this.channelTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Channel:";
            // 
            // connectButton
            // 
            this.connectButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.connectButton.Location = new System.Drawing.Point(98, 216);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(260, 48);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // loginPopoutButton
            // 
            this.loginPopoutButton.Location = new System.Drawing.Point(12, 35);
            this.loginPopoutButton.Name = "loginPopoutButton";
            this.loginPopoutButton.Size = new System.Drawing.Size(75, 23);
            this.loginPopoutButton.TabIndex = 3;
            this.loginPopoutButton.Text = "Log In";
            this.loginPopoutButton.UseVisualStyleBackColor = true;
            this.loginPopoutButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // useWowieBox
            // 
            this.useWowieBox.AutoSize = true;
            this.useWowieBox.Checked = true;
            this.useWowieBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useWowieBox.Location = new System.Drawing.Point(12, 12);
            this.useWowieBox.Name = "useWowieBox";
            this.useWowieBox.Size = new System.Drawing.Size(117, 17);
            this.useWowieBox.TabIndex = 4;
            this.useWowieBox.Text = "Log in as wowiebot";
            this.useWowieBox.UseVisualStyleBackColor = true;
            this.useWowieBox.CheckedChanged += new System.EventHandler(this.useWowieBox_CheckedChanged);
            // 
            // configButton
            // 
            this.configButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.configButton.Location = new System.Drawing.Point(368, 8);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(75, 23);
            this.configButton.TabIndex = 5;
            this.configButton.Text = "Configure";
            this.configButton.UseVisualStyleBackColor = true;
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // serverOutTextBox
            // 
            this.serverOutTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverOutTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.serverOutTextBox.Location = new System.Drawing.Point(12, 64);
            this.serverOutTextBox.Multiline = true;
            this.serverOutTextBox.Name = "serverOutTextBox";
            this.serverOutTextBox.ReadOnly = true;
            this.serverOutTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverOutTextBox.Size = new System.Drawing.Size(431, 117);
            this.serverOutTextBox.TabIndex = 6;
            this.serverOutTextBox.TabStop = false;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateButton.Location = new System.Drawing.Point(368, 35);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 7;
            this.updateButton.Text = "Update!";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Visible = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // songRequestButton
            // 
            this.songRequestButton.Location = new System.Drawing.Point(168, 12);
            this.songRequestButton.Name = "songRequestButton";
            this.songRequestButton.Size = new System.Drawing.Size(125, 23);
            this.songRequestButton.TabIndex = 8;
            this.songRequestButton.Text = "Song Requests";
            this.songRequestButton.UseVisualStyleBackColor = true;
            this.songRequestButton.Click += new System.EventHandler(this.songRequestButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.connectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 276);
            this.Controls.Add(this.songRequestButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.serverOutTextBox);
            this.Controls.Add(this.configButton);
            this.Controls.Add(this.useWowieBox);
            this.Controls.Add(this.loginPopoutButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.channelTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(471, 315);
            this.Name = "MainForm";
            this.Text = "wowiebot launchpad";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox channelTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button loginPopoutButton;
        private System.Windows.Forms.CheckBox useWowieBox;
        private System.Windows.Forms.Button configButton;
        private System.Windows.Forms.TextBox serverOutTextBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button songRequestButton;
    }
}

