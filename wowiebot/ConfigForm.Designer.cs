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
            this.label8 = new System.Windows.Forms.Label();
            this.addCommandsBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.songRequestAddCommand = new System.Windows.Forms.Button();
            this.calculatorButton = new System.Windows.Forms.Button();
            this.helpCommandAddButton = new System.Windows.Forms.Button();
            this.eightBallButton = new System.Windows.Forms.Button();
            this.titleGameButton = new System.Windows.Forms.Button();
            this.uptimeButton = new System.Windows.Forms.Button();
            this.getQuoteButton = new System.Windows.Forms.Button();
            this.addQuoteButton = new System.Windows.Forms.Button();
            this.addMessageCommandButton = new System.Windows.Forms.Button();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.noPermsMsgTextBox = new System.Windows.Forms.TextBox();
            this.bitsMessageThresholdBox = new System.Windows.Forms.NumericUpDown();
            this.messageOnCheerBox = new System.Windows.Forms.TextBox();
            this.emptyQuoteMessage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.periodicSpamPrevent = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.periodicPeriodPicker = new System.Windows.Forms.NumericUpDown();
            this.periodicTextBox = new System.Windows.Forms.TextBox();
            this.eightBallBox = new System.Windows.Forms.TextBox();
            this.quotesTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.quoteVotersNum = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.addCommandsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bitsMessageThresholdBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodicSpamPrevent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodicPeriodPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteVotersNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(19, 17);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 831);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.addCommandsBox);
            this.tabPage1.Controls.Add(this.prefixTextBox);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(721, 923);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Commands";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Command Prefix";
            // 
            // addCommandsBox
            // 
            this.addCommandsBox.Controls.Add(this.button1);
            this.addCommandsBox.Controls.Add(this.songRequestAddCommand);
            this.addCommandsBox.Controls.Add(this.calculatorButton);
            this.addCommandsBox.Controls.Add(this.helpCommandAddButton);
            this.addCommandsBox.Controls.Add(this.eightBallButton);
            this.addCommandsBox.Controls.Add(this.titleGameButton);
            this.addCommandsBox.Controls.Add(this.uptimeButton);
            this.addCommandsBox.Controls.Add(this.getQuoteButton);
            this.addCommandsBox.Controls.Add(this.addQuoteButton);
            this.addCommandsBox.Controls.Add(this.addMessageCommandButton);
            this.addCommandsBox.Location = new System.Drawing.Point(13, 35);
            this.addCommandsBox.Name = "addCommandsBox";
            this.addCommandsBox.Size = new System.Drawing.Size(520, 84);
            this.addCommandsBox.TabIndex = 5;
            this.addCommandsBox.TabStop = false;
            this.addCommandsBox.Text = "Quick Add Commands";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Song Queue Length";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // songRequestAddCommand
            // 
            this.songRequestAddCommand.Location = new System.Drawing.Point(25, 48);
            this.songRequestAddCommand.Name = "songRequestAddCommand";
            this.songRequestAddCommand.Size = new System.Drawing.Size(94, 23);
            this.songRequestAddCommand.TabIndex = 8;
            this.songRequestAddCommand.Text = "Request Song";
            this.songRequestAddCommand.UseVisualStyleBackColor = true;
            this.songRequestAddCommand.Click += new System.EventHandler(this.songRequestAddCommand_Click);
            // 
            // calculatorButton
            // 
            this.calculatorButton.Location = new System.Drawing.Point(332, 48);
            this.calculatorButton.Name = "calculatorButton";
            this.calculatorButton.Size = new System.Drawing.Size(75, 23);
            this.calculatorButton.TabIndex = 7;
            this.calculatorButton.Text = "Calculator";
            this.calculatorButton.UseVisualStyleBackColor = true;
            this.calculatorButton.Click += new System.EventHandler(this.calculatorButton_Click);
            // 
            // helpCommandAddButton
            // 
            this.helpCommandAddButton.Location = new System.Drawing.Point(251, 48);
            this.helpCommandAddButton.Name = "helpCommandAddButton";
            this.helpCommandAddButton.Size = new System.Drawing.Size(75, 23);
            this.helpCommandAddButton.TabIndex = 6;
            this.helpCommandAddButton.Text = "Help";
            this.helpCommandAddButton.UseVisualStyleBackColor = true;
            this.helpCommandAddButton.Click += new System.EventHandler(this.helpCommandAddButton_Click);
            // 
            // eightBallButton
            // 
            this.eightBallButton.Location = new System.Drawing.Point(430, 19);
            this.eightBallButton.Name = "eightBallButton";
            this.eightBallButton.Size = new System.Drawing.Size(75, 23);
            this.eightBallButton.TabIndex = 5;
            this.eightBallButton.Text = "8-Ball";
            this.eightBallButton.UseVisualStyleBackColor = true;
            this.eightBallButton.Click += new System.EventHandler(this.eightBallButton_Click);
            // 
            // titleGameButton
            // 
            this.titleGameButton.Location = new System.Drawing.Point(349, 19);
            this.titleGameButton.Name = "titleGameButton";
            this.titleGameButton.Size = new System.Drawing.Size(75, 23);
            this.titleGameButton.TabIndex = 4;
            this.titleGameButton.Text = "Title/Game";
            this.titleGameButton.UseVisualStyleBackColor = true;
            this.titleGameButton.Click += new System.EventHandler(this.titleGameButton_Click);
            // 
            // uptimeButton
            // 
            this.uptimeButton.Location = new System.Drawing.Point(268, 19);
            this.uptimeButton.Name = "uptimeButton";
            this.uptimeButton.Size = new System.Drawing.Size(75, 23);
            this.uptimeButton.TabIndex = 3;
            this.uptimeButton.Text = "Uptime";
            this.uptimeButton.UseVisualStyleBackColor = true;
            this.uptimeButton.Click += new System.EventHandler(this.uptimeButton_Click);
            // 
            // getQuoteButton
            // 
            this.getQuoteButton.Location = new System.Drawing.Point(187, 19);
            this.getQuoteButton.Name = "getQuoteButton";
            this.getQuoteButton.Size = new System.Drawing.Size(75, 23);
            this.getQuoteButton.TabIndex = 2;
            this.getQuoteButton.Text = "Get Quote";
            this.getQuoteButton.UseVisualStyleBackColor = true;
            this.getQuoteButton.Click += new System.EventHandler(this.getQuoteButton_Click);
            // 
            // addQuoteButton
            // 
            this.addQuoteButton.Location = new System.Drawing.Point(106, 19);
            this.addQuoteButton.Name = "addQuoteButton";
            this.addQuoteButton.Size = new System.Drawing.Size(75, 23);
            this.addQuoteButton.TabIndex = 1;
            this.addQuoteButton.Text = "Add Quote";
            this.addQuoteButton.UseVisualStyleBackColor = true;
            this.addQuoteButton.Click += new System.EventHandler(this.addQuoteButton_Click);
            // 
            // addMessageCommandButton
            // 
            this.addMessageCommandButton.Location = new System.Drawing.Point(25, 19);
            this.addMessageCommandButton.Name = "addMessageCommandButton";
            this.addMessageCommandButton.Size = new System.Drawing.Size(75, 23);
            this.addMessageCommandButton.TabIndex = 0;
            this.addMessageCommandButton.Text = "Message";
            this.addMessageCommandButton.UseVisualStyleBackColor = true;
            this.addMessageCommandButton.Click += new System.EventHandler(this.addMessageCommandButton_Click);
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Location = new System.Drawing.Point(101, 9);
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
            this.dataGridView1.Location = new System.Drawing.Point(13, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(692, 787);
            this.dataGridView1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.githubLink);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.quoteVotersNum);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.periodicSpamPrevent);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.periodicPeriodPicker);
            this.tabPage2.Controls.Add(this.periodicTextBox);
            this.tabPage2.Controls.Add(this.eightBallBox);
            this.tabPage2.Controls.Add(this.quotesTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(721, 805);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Text Strings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.noPermsMsgTextBox);
            this.groupBox1.Controls.Add(this.bitsMessageThresholdBox);
            this.groupBox1.Controls.Add(this.messageOnCheerBox);
            this.groupBox1.Controls.Add(this.emptyQuoteMessage);
            this.groupBox1.Location = new System.Drawing.Point(340, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 651);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event Messages (leave blank to disable)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(255, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Available tokens: $COUNT = number of bits cheered";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(262, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Tokens available in all: $SENDER, $BROADCASTER";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(296, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Response to command when sender doesn\'t have permission";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(198, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "or more bits";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Response to cheers of";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(242, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Response to quote command on empty quotes list";
            // 
            // noPermsMsgTextBox
            // 
            this.noPermsMsgTextBox.Location = new System.Drawing.Point(26, 228);
            this.noPermsMsgTextBox.Name = "noPermsMsgTextBox";
            this.noPermsMsgTextBox.Size = new System.Drawing.Size(316, 20);
            this.noPermsMsgTextBox.TabIndex = 4;
            // 
            // bitsMessageThresholdBox
            // 
            this.bitsMessageThresholdBox.Location = new System.Drawing.Point(140, 115);
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
            this.bitsMessageThresholdBox.Size = new System.Drawing.Size(55, 20);
            this.bitsMessageThresholdBox.TabIndex = 6;
            this.bitsMessageThresholdBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // messageOnCheerBox
            // 
            this.messageOnCheerBox.Location = new System.Drawing.Point(26, 138);
            this.messageOnCheerBox.Name = "messageOnCheerBox";
            this.messageOnCheerBox.Size = new System.Drawing.Size(316, 20);
            this.messageOnCheerBox.TabIndex = 5;
            // 
            // emptyQuoteMessage
            // 
            this.emptyQuoteMessage.Location = new System.Drawing.Point(26, 73);
            this.emptyQuoteMessage.Name = "emptyQuoteMessage";
            this.emptyQuoteMessage.Size = new System.Drawing.Size(316, 20);
            this.emptyQuoteMessage.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 686);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(241, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "messages have been sent since last bot message";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 668);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Spam prevention: don\'t send unless";
            // 
            // periodicSpamPrevent
            // 
            this.periodicSpamPrevent.Location = new System.Drawing.Point(210, 665);
            this.periodicSpamPrevent.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.periodicSpamPrevent.Name = "periodicSpamPrevent";
            this.periodicSpamPrevent.Size = new System.Drawing.Size(44, 20);
            this.periodicSpamPrevent.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 468);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "minutes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 468);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sent in chat every";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Periodic messages (one per line)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "8-Ball choices (one per line)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quotes (one per line)";
            // 
            // periodicPeriodPicker
            // 
            this.periodicPeriodPicker.Location = new System.Drawing.Point(129, 466);
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
            this.periodicPeriodPicker.Size = new System.Drawing.Size(44, 20);
            this.periodicPeriodPicker.TabIndex = 8;
            this.periodicPeriodPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // periodicTextBox
            // 
            this.periodicTextBox.Location = new System.Drawing.Point(33, 491);
            this.periodicTextBox.Multiline = true;
            this.periodicTextBox.Name = "periodicTextBox";
            this.periodicTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.periodicTextBox.Size = new System.Drawing.Size(275, 170);
            this.periodicTextBox.TabIndex = 2;
            this.periodicTextBox.WordWrap = false;
            // 
            // eightBallBox
            // 
            this.eightBallBox.Location = new System.Drawing.Point(33, 260);
            this.eightBallBox.Multiline = true;
            this.eightBallBox.Name = "eightBallBox";
            this.eightBallBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.eightBallBox.Size = new System.Drawing.Size(275, 170);
            this.eightBallBox.TabIndex = 1;
            this.eightBallBox.WordWrap = false;
            // 
            // quotesTextBox
            // 
            this.quotesTextBox.Location = new System.Drawing.Point(33, 29);
            this.quotesTextBox.Multiline = true;
            this.quotesTextBox.Name = "quotesTextBox";
            this.quotesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.quotesTextBox.Size = new System.Drawing.Size(275, 157);
            this.quotesTextBox.TabIndex = 0;
            this.quotesTextBox.WordWrap = false;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(687, 866);
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
            this.exportButton.Location = new System.Drawing.Point(19, 866);
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
            this.importButton.Location = new System.Drawing.Point(121, 866);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(96, 23);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "Import Settings";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 287);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(316, 20);
            this.textBox1.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 268);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(196, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Response when links are posted in chat";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(29, 314);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(248, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Available tokens: $TITLE = page title of link posted";
            // 
            // quoteVotersNum
            // 
            this.quoteVotersNum.Location = new System.Drawing.Point(168, 192);
            this.quoteVotersNum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.quoteVotersNum.Name = "quoteVotersNum";
            this.quoteVotersNum.Size = new System.Drawing.Size(60, 20);
            this.quoteVotersNum.TabIndex = 18;
            this.quoteVotersNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(37, 194);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Added when voted yes by";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(231, 194);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "people";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(40, 211);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(109, 13);
            this.label21.TabIndex = 21;
            this.label21.Text = "(0 to add immediately)";
            // 
            // githubLink
            // 
            this.githubLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.githubLink.AutoSize = true;
            this.githubLink.Location = new System.Drawing.Point(108, 761);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(116, 13);
            this.githubLink.TabIndex = 24;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "View source on GitHub";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(108, 746);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(158, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "wowiebot by scatter 2016-2019.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::wowiebot.Properties.Resources.vanessabirdcropped_1mb;
            this.pictureBox1.Location = new System.Drawing.Point(18, 710);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 901);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(790, 940);
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.addCommandsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bitsMessageThresholdBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodicSpamPrevent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodicPeriodPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteVotersNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox quotesTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox eightBallBox;
        private System.Windows.Forms.TextBox periodicTextBox;
        private System.Windows.Forms.TextBox noPermsMsgTextBox;
        private System.Windows.Forms.TextBox messageOnCheerBox;
        private System.Windows.Forms.NumericUpDown bitsMessageThresholdBox;
        private System.Windows.Forms.TextBox emptyQuoteMessage;
        private System.Windows.Forms.NumericUpDown periodicPeriodPicker;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.GroupBox addCommandsBox;
        private System.Windows.Forms.Button addMessageCommandButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown periodicSpamPrevent;
        private System.Windows.Forms.Button calculatorButton;
        private System.Windows.Forms.Button helpCommandAddButton;
        private System.Windows.Forms.Button eightBallButton;
        private System.Windows.Forms.Button titleGameButton;
        private System.Windows.Forms.Button uptimeButton;
        private System.Windows.Forms.Button getQuoteButton;
        private System.Windows.Forms.Button addQuoteButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button songRequestAddCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel githubLink;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown quoteVotersNum;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
    }
}