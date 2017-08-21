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
            this.prefixLabel = new System.Windows.Forms.Label();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.linkCheckBox = new System.Windows.Forms.CheckBox();
            this.editQuotesButton = new System.Windows.Forms.Button();
            this.edit8BallChoicesButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.quoteMethodDropDown = new System.Windows.Forms.ComboBox();
            this.quoteMethodLabel = new System.Windows.Forms.Label();
            this.quoteVotersNumLabel = new System.Windows.Forms.Label();
            this.quoteVotersNum = new System.Windows.Forms.NumericUpDown();
            this.emptyQuoteMessage = new System.Windows.Forms.TextBox();
            this.emptyQuotesLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteVotersNum)).BeginInit();
            this.SuspendLayout();
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
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(40, 504);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(121, 504);
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
            this.linkCheckBox.Location = new System.Drawing.Point(12, 70);
            this.linkCheckBox.Name = "linkCheckBox";
            this.linkCheckBox.Size = new System.Drawing.Size(103, 17);
            this.linkCheckBox.TabIndex = 7;
            this.linkCheckBox.Text = "Display link titles";
            this.linkCheckBox.UseVisualStyleBackColor = true;
            // 
            // editQuotesButton
            // 
            this.editQuotesButton.Location = new System.Drawing.Point(12, 12);
            this.editQuotesButton.Name = "editQuotesButton";
            this.editQuotesButton.Size = new System.Drawing.Size(75, 23);
            this.editQuotesButton.TabIndex = 12;
            this.editQuotesButton.Text = "Edit Quotes";
            this.editQuotesButton.UseVisualStyleBackColor = true;
            this.editQuotesButton.Click += new System.EventHandler(this.editQuotesButton_Click);
            // 
            // edit8BallChoicesButton
            // 
            this.edit8BallChoicesButton.Location = new System.Drawing.Point(12, 41);
            this.edit8BallChoicesButton.Name = "edit8BallChoicesButton";
            this.edit8BallChoicesButton.Size = new System.Drawing.Size(114, 23);
            this.edit8BallChoicesButton.TabIndex = 13;
            this.edit8BallChoicesButton.Text = "Edit 8-Ball Choices";
            this.edit8BallChoicesButton.UseVisualStyleBackColor = true;
            this.edit8BallChoicesButton.Click += new System.EventHandler(this.edit8BallChoicesButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(273, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(489, 486);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(17, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Commands";
            // 
            // quoteMethodDropDown
            // 
            this.quoteMethodDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quoteMethodDropDown.FormattingEnabled = true;
            this.quoteMethodDropDown.Location = new System.Drawing.Point(12, 110);
            this.quoteMethodDropDown.Name = "quoteMethodDropDown";
            this.quoteMethodDropDown.Size = new System.Drawing.Size(234, 21);
            this.quoteMethodDropDown.TabIndex = 17;
            this.quoteMethodDropDown.SelectedIndexChanged += new System.EventHandler(this.quoteMethodDropDown_SelectedIndexChanged);
            // 
            // quoteMethodLabel
            // 
            this.quoteMethodLabel.AutoSize = true;
            this.quoteMethodLabel.Location = new System.Drawing.Point(13, 94);
            this.quoteMethodLabel.Name = "quoteMethodLabel";
            this.quoteMethodLabel.Size = new System.Drawing.Size(131, 13);
            this.quoteMethodLabel.TabIndex = 18;
            this.quoteMethodLabel.Text = "Quote adding permissions:";
            // 
            // quoteVotersNumLabel
            // 
            this.quoteVotersNumLabel.AutoSize = true;
            this.quoteVotersNumLabel.Location = new System.Drawing.Point(9, 146);
            this.quoteVotersNumLabel.Name = "quoteVotersNumLabel";
            this.quoteVotersNumLabel.Size = new System.Drawing.Size(258, 13);
            this.quoteVotersNumLabel.TabIndex = 19;
            this.quoteVotersNumLabel.Text = "Votes required to add quote (including original adder):";
            // 
            // quoteVotersNum
            // 
            this.quoteVotersNum.Location = new System.Drawing.Point(12, 162);
            this.quoteVotersNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.quoteVotersNum.Name = "quoteVotersNum";
            this.quoteVotersNum.Size = new System.Drawing.Size(36, 20);
            this.quoteVotersNum.TabIndex = 20;
            this.quoteVotersNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // emptyQuoteMessage
            // 
            this.emptyQuoteMessage.Location = new System.Drawing.Point(12, 205);
            this.emptyQuoteMessage.Name = "emptyQuoteMessage";
            this.emptyQuoteMessage.Size = new System.Drawing.Size(255, 20);
            this.emptyQuoteMessage.TabIndex = 21;
            this.emptyQuoteMessage.TextChanged += new System.EventHandler(this.emptyQuoteMessage_TextChanged);
            // 
            // emptyQuotesLabel
            // 
            this.emptyQuotesLabel.AutoSize = true;
            this.emptyQuotesLabel.Location = new System.Drawing.Point(12, 189);
            this.emptyQuotesLabel.Name = "emptyQuotesLabel";
            this.emptyQuotesLabel.Size = new System.Drawing.Size(181, 13);
            this.emptyQuotesLabel.TabIndex = 22;
            this.emptyQuotesLabel.Text = "Message for when quotes are empty:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Periodic Messages";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(774, 540);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.emptyQuotesLabel);
            this.Controls.Add(this.emptyQuoteMessage);
            this.Controls.Add(this.quoteVotersNum);
            this.Controls.Add(this.quoteVotersNumLabel);
            this.Controls.Add(this.quoteMethodLabel);
            this.Controls.Add(this.quoteMethodDropDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.edit8BallChoicesButton);
            this.Controls.Add(this.editQuotesButton);
            this.Controls.Add(this.linkCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.prefixTextBox);
            this.Controls.Add(this.prefixLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(790, 579);
            this.Name = "ConfigForm";
            this.Text = "Config";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteVotersNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label prefixLabel;
        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox linkCheckBox;
        private System.Windows.Forms.Button editQuotesButton;
        private System.Windows.Forms.Button edit8BallChoicesButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox quoteMethodDropDown;
        private System.Windows.Forms.Label quoteMethodLabel;
        private System.Windows.Forms.Label quoteVotersNumLabel;
        private System.Windows.Forms.NumericUpDown quoteVotersNum;
        private System.Windows.Forms.TextBox emptyQuoteMessage;
        private System.Windows.Forms.Label emptyQuotesLabel;
        private System.Windows.Forms.Button button2;
    }
}