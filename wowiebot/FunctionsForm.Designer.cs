namespace wowiebot
{
    partial class FunctionsForm
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
            this.quoteCheckBox = new System.Windows.Forms.CheckBox();
            this.titleCheckBox = new System.Windows.Forms.CheckBox();
            this.uptimeCheckBox = new System.Windows.Forms.CheckBox();
            this.prefixLabel = new System.Windows.Forms.Label();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.linkCheckBox = new System.Windows.Forms.CheckBox();
            this.yeahBoiCheckBox = new System.Windows.Forms.CheckBox();
            this.discordCheckBox = new System.Windows.Forms.CheckBox();
            this.discordTextBox = new System.Windows.Forms.TextBox();
            this.eightBallCheckBox = new System.Windows.Forms.CheckBox();
            this.editQuotesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // quoteCheckBox
            // 
            this.quoteCheckBox.AutoSize = true;
            this.quoteCheckBox.Location = new System.Drawing.Point(12, 12);
            this.quoteCheckBox.Name = "quoteCheckBox";
            this.quoteCheckBox.Size = new System.Drawing.Size(56, 17);
            this.quoteCheckBox.TabIndex = 0;
            this.quoteCheckBox.Text = "!quote";
            this.quoteCheckBox.UseVisualStyleBackColor = true;
            this.quoteCheckBox.CheckedChanged += new System.EventHandler(this.quoteCheckBox_CheckedChanged);
            // 
            // titleCheckBox
            // 
            this.titleCheckBox.AutoSize = true;
            this.titleCheckBox.Location = new System.Drawing.Point(12, 35);
            this.titleCheckBox.Name = "titleCheckBox";
            this.titleCheckBox.Size = new System.Drawing.Size(80, 17);
            this.titleCheckBox.TabIndex = 1;
            this.titleCheckBox.Text = "!title, !game";
            this.titleCheckBox.UseVisualStyleBackColor = true;
            // 
            // uptimeCheckBox
            // 
            this.uptimeCheckBox.AutoSize = true;
            this.uptimeCheckBox.Location = new System.Drawing.Point(12, 58);
            this.uptimeCheckBox.Name = "uptimeCheckBox";
            this.uptimeCheckBox.Size = new System.Drawing.Size(60, 17);
            this.uptimeCheckBox.TabIndex = 2;
            this.uptimeCheckBox.Text = "!uptime";
            this.uptimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // prefixLabel
            // 
            this.prefixLabel.AutoSize = true;
            this.prefixLabel.Location = new System.Drawing.Point(170, 9);
            this.prefixLabel.Name = "prefixLabel";
            this.prefixLabel.Size = new System.Drawing.Size(33, 13);
            this.prefixLabel.TabIndex = 3;
            this.prefixLabel.Text = "Prefix";
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Location = new System.Drawing.Point(173, 25);
            this.prefixTextBox.MaxLength = 1;
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.Size = new System.Drawing.Size(32, 20);
            this.prefixTextBox.TabIndex = 4;
            this.prefixTextBox.TextChanged += new System.EventHandler(this.prefixTextBox_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(28, 180);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(109, 180);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // linkCheckBox
            // 
            this.linkCheckBox.AutoSize = true;
            this.linkCheckBox.Location = new System.Drawing.Point(12, 82);
            this.linkCheckBox.Name = "linkCheckBox";
            this.linkCheckBox.Size = new System.Drawing.Size(103, 17);
            this.linkCheckBox.TabIndex = 7;
            this.linkCheckBox.Text = "Display link titles";
            this.linkCheckBox.UseVisualStyleBackColor = true;
            // 
            // yeahBoiCheckBox
            // 
            this.yeahBoiCheckBox.AutoSize = true;
            this.yeahBoiCheckBox.Location = new System.Drawing.Point(12, 106);
            this.yeahBoiCheckBox.Name = "yeahBoiCheckBox";
            this.yeahBoiCheckBox.Size = new System.Drawing.Size(131, 17);
            this.yeahBoiCheckBox.TabIndex = 8;
            this.yeahBoiCheckBox.Text = "Longest yeah boi ever";
            this.yeahBoiCheckBox.UseVisualStyleBackColor = true;
            // 
            // discordCheckBox
            // 
            this.discordCheckBox.AutoSize = true;
            this.discordCheckBox.Location = new System.Drawing.Point(12, 130);
            this.discordCheckBox.Name = "discordCheckBox";
            this.discordCheckBox.Size = new System.Drawing.Size(63, 17);
            this.discordCheckBox.TabIndex = 9;
            this.discordCheckBox.Text = "!discord";
            this.discordCheckBox.UseVisualStyleBackColor = true;
            this.discordCheckBox.CheckedChanged += new System.EventHandler(this.discordCheckBox_CheckedChanged);
            // 
            // discordTextBox
            // 
            this.discordTextBox.Location = new System.Drawing.Point(81, 128);
            this.discordTextBox.Name = "discordTextBox";
            this.discordTextBox.Size = new System.Drawing.Size(100, 20);
            this.discordTextBox.TabIndex = 10;
            this.discordTextBox.Text = "https://";
            this.discordTextBox.TextChanged += new System.EventHandler(this.discordTextBox_TextChanged);
            // 
            // eightBallCheckBox
            // 
            this.eightBallCheckBox.AutoSize = true;
            this.eightBallCheckBox.Location = new System.Drawing.Point(12, 154);
            this.eightBallCheckBox.Name = "eightBallCheckBox";
            this.eightBallCheckBox.Size = new System.Drawing.Size(51, 17);
            this.eightBallCheckBox.TabIndex = 11;
            this.eightBallCheckBox.Text = "!8ball";
            this.eightBallCheckBox.UseVisualStyleBackColor = true;
            // 
            // editQuotesButton
            // 
            this.editQuotesButton.Location = new System.Drawing.Point(68, 8);
            this.editQuotesButton.Name = "editQuotesButton";
            this.editQuotesButton.Size = new System.Drawing.Size(75, 23);
            this.editQuotesButton.TabIndex = 12;
            this.editQuotesButton.Text = "Edit Quotes";
            this.editQuotesButton.UseVisualStyleBackColor = true;
            this.editQuotesButton.Click += new System.EventHandler(this.editQuotesButton_Click);
            // 
            // FunctionsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(215, 215);
            this.Controls.Add(this.editQuotesButton);
            this.Controls.Add(this.eightBallCheckBox);
            this.Controls.Add(this.discordTextBox);
            this.Controls.Add(this.discordCheckBox);
            this.Controls.Add(this.yeahBoiCheckBox);
            this.Controls.Add(this.linkCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.prefixTextBox);
            this.Controls.Add(this.prefixLabel);
            this.Controls.Add(this.uptimeCheckBox);
            this.Controls.Add(this.titleCheckBox);
            this.Controls.Add(this.quoteCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FunctionsForm";
            this.Text = "Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox titleCheckBox;
        private System.Windows.Forms.CheckBox uptimeCheckBox;
        private System.Windows.Forms.Label prefixLabel;
        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox quoteCheckBox;
        private System.Windows.Forms.CheckBox linkCheckBox;
        private System.Windows.Forms.CheckBox yeahBoiCheckBox;
        private System.Windows.Forms.CheckBox discordCheckBox;
        private System.Windows.Forms.TextBox discordTextBox;
        private System.Windows.Forms.CheckBox eightBallCheckBox;
        private System.Windows.Forms.Button editQuotesButton;
    }
}