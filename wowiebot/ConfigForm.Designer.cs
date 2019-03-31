namespace wowiebot
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.periodicPeriodPicker = new System.Windows.Forms.NumericUpDown();
            this.emptyQuoteMessage = new System.Windows.Forms.TextBox();
            this.bitsMessageThresholdBox = new System.Windows.Forms.NumericUpDown();
            this.messageOnCheerBox = new System.Windows.Forms.TextBox();
            this.noPermsMsgTextBox = new System.Windows.Forms.TextBox();
            this.periodicTextBox = new System.Windows.Forms.TextBox();
            this.eightBallBox = new System.Windows.Forms.TextBox();
            this.quotesTextBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkCheckBox = new System.Windows.Forms.CheckBox();
            this.quoteVotersNum = new System.Windows.Forms.NumericUpDown();
            this.quoteMethodDropDown = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.addCommandsBox = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.periodicPeriodPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitsMessageThresholdBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quoteVotersNum)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(19, 17);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 706);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.addCommandsBox);
            this.tabPage1.Controls.Add(this.prefixTextBox);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(721, 680);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Commands";
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Location = new System.Drawing.Point(61, 25);
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.Size = new System.Drawing.Size(31, 20);
            this.prefixTextBox.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 189);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(692, 480);
            this.dataGridView1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.periodicPeriodPicker);
            this.tabPage2.Controls.Add(this.emptyQuoteMessage);
            this.tabPage2.Controls.Add(this.bitsMessageThresholdBox);
            this.tabPage2.Controls.Add(this.messageOnCheerBox);
            this.tabPage2.Controls.Add(this.noPermsMsgTextBox);
            this.tabPage2.Controls.Add(this.periodicTextBox);
            this.tabPage2.Controls.Add(this.eightBallBox);
            this.tabPage2.Controls.Add(this.quotesTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(721, 680);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Text Strings";
            // 
            // periodicPeriodPicker
            // 
            this.periodicPeriodPicker.Location = new System.Drawing.Point(188, 410);
            this.periodicPeriodPicker.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.periodicPeriodPicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.periodicPeriodPicker.Name = "periodicPeriodPicker";
            this.periodicPeriodPicker.Size = new System.Drawing.Size(120, 20);
            this.periodicPeriodPicker.TabIndex = 8;
            this.periodicPeriodPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // emptyQuoteMessage
            // 
            this.emptyQuoteMessage.Location = new System.Drawing.Point(404, 456);
            this.emptyQuoteMessage.Name = "emptyQuoteMessage";
            this.emptyQuoteMessage.Size = new System.Drawing.Size(100, 20);
            this.emptyQuoteMessage.TabIndex = 7;
            // 
            // bitsMessageThresholdBox
            // 
            this.bitsMessageThresholdBox.Location = new System.Drawing.Point(568, 309);
            this.bitsMessageThresholdBox.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.bitsMessageThresholdBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bitsMessageThresholdBox.Name = "bitsMessageThresholdBox";
            this.bitsMessageThresholdBox.Size = new System.Drawing.Size(67, 20);
            this.bitsMessageThresholdBox.TabIndex = 6;
            this.bitsMessageThresholdBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // messageOnCheerBox
            // 
            this.messageOnCheerBox.Location = new System.Drawing.Point(404, 346);
            this.messageOnCheerBox.Name = "messageOnCheerBox";
            this.messageOnCheerBox.Size = new System.Drawing.Size(267, 20);
            this.messageOnCheerBox.TabIndex = 5;
            // 
            // noPermsMsgTextBox
            // 
            this.noPermsMsgTextBox.Location = new System.Drawing.Point(458, 162);
            this.noPermsMsgTextBox.Name = "noPermsMsgTextBox";
            this.noPermsMsgTextBox.Size = new System.Drawing.Size(225, 20);
            this.noPermsMsgTextBox.TabIndex = 4;
            // 
            // periodicTextBox
            // 
            this.periodicTextBox.Location = new System.Drawing.Point(33, 445);
            this.periodicTextBox.Multiline = true;
            this.periodicTextBox.Name = "periodicTextBox";
            this.periodicTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.periodicTextBox.Size = new System.Drawing.Size(275, 170);
            this.periodicTextBox.TabIndex = 2;
            this.periodicTextBox.WordWrap = false;
            // 
            // eightBallBox
            // 
            this.eightBallBox.Location = new System.Drawing.Point(33, 202);
            this.eightBallBox.Multiline = true;
            this.eightBallBox.Name = "eightBallBox";
            this.eightBallBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.eightBallBox.Size = new System.Drawing.Size(275, 170);
            this.eightBallBox.TabIndex = 1;
            this.eightBallBox.WordWrap = false;
            // 
            // quotesTextBox
            // 
            this.quotesTextBox.Location = new System.Drawing.Point(33, 25);
            this.quotesTextBox.Multiline = true;
            this.quotesTextBox.Name = "quotesTextBox";
            this.quotesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.quotesTextBox.Size = new System.Drawing.Size(275, 157);
            this.quotesTextBox.TabIndex = 0;
            this.quotesTextBox.WordWrap = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linkCheckBox);
            this.tabPage3.Controls.Add(this.quoteVotersNum);
            this.tabPage3.Controls.Add(this.quoteMethodDropDown);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(721, 680);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Options";
            // 
            // linkCheckBox
            // 
            this.linkCheckBox.AutoSize = true;
            this.linkCheckBox.Location = new System.Drawing.Point(94, 241);
            this.linkCheckBox.Name = "linkCheckBox";
            this.linkCheckBox.Size = new System.Drawing.Size(177, 17);
            this.linkCheckBox.TabIndex = 2;
            this.linkCheckBox.Text = "Bot will post titles of posted links";
            this.linkCheckBox.UseVisualStyleBackColor = true;
            // 
            // quoteVotersNum
            // 
            this.quoteVotersNum.Location = new System.Drawing.Point(68, 130);
            this.quoteVotersNum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.quoteVotersNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quoteVotersNum.Name = "quoteVotersNum";
            this.quoteVotersNum.Size = new System.Drawing.Size(120, 20);
            this.quoteVotersNum.TabIndex = 1;
            this.quoteVotersNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // quoteMethodDropDown
            // 
            this.quoteMethodDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quoteMethodDropDown.FormattingEnabled = true;
            this.quoteMethodDropDown.Location = new System.Drawing.Point(51, 66);
            this.quoteMethodDropDown.Name = "quoteMethodDropDown";
            this.quoteMethodDropDown.Size = new System.Drawing.Size(220, 21);
            this.quoteMethodDropDown.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(687, 741);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportButton.Location = new System.Drawing.Point(19, 741);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(96, 23);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export Settings";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importButton.Location = new System.Drawing.Point(121, 741);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(96, 23);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "Import Settings";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // addCommandsBox
            // 
            this.addCommandsBox.Location = new System.Drawing.Point(13, 60);
            this.addCommandsBox.Name = "addCommandsBox";
            this.addCommandsBox.Size = new System.Drawing.Size(624, 102);
            this.addCommandsBox.TabIndex = 5;
            this.addCommandsBox.TabStop = false;
            this.addCommandsBox.Text = "Add Commands:";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 776);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(790, 579);
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.periodicPeriodPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitsMessageThresholdBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quoteVotersNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox quotesTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox eightBallBox;
        private System.Windows.Forms.TextBox periodicTextBox;
        private System.Windows.Forms.TextBox noPermsMsgTextBox;
        private System.Windows.Forms.TextBox messageOnCheerBox;
        private System.Windows.Forms.NumericUpDown bitsMessageThresholdBox;
        private System.Windows.Forms.TextBox emptyQuoteMessage;
        private System.Windows.Forms.NumericUpDown periodicPeriodPicker;
        private System.Windows.Forms.ComboBox quoteMethodDropDown;
        private System.Windows.Forms.NumericUpDown quoteVotersNum;
        private System.Windows.Forms.CheckBox linkCheckBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.GroupBox addCommandsBox;
    }
}