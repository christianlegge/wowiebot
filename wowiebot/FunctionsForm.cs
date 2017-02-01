using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wowiebot
{
    public partial class FunctionsForm : Form
    {
        public FunctionsForm()
        {
            InitializeComponent();
            discordTextBox.Enabled = discordCheckBox.Checked;
            prefixTextBox.Text = Properties.Settings.Default.prefix;
            quoteCheckBox.Checked = Properties.Settings.Default.enableQuotes;
            uptimeCheckBox.Checked = Properties.Settings.Default.enableUptime;
            titleCheckBox.Checked = Properties.Settings.Default.enableTitle;
            linkCheckBox.Checked = Properties.Settings.Default.enableLinkTitles;
            yeahBoiCheckBox.Checked = Properties.Settings.Default.enableYeahBoi;
            discordCheckBox.Checked = Properties.Settings.Default.enableDiscord;
            if (Properties.Settings.Default.enableDiscord)
            {
                discordTextBox.Text = Properties.Settings.Default.discordServer;
            }
            else
            {
                discordTextBox.Text = "https://";
            }
            updateSaveButton();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.prefix = prefixTextBox.Text;
            Properties.Settings.Default.enableQuotes = quoteCheckBox.Checked;
            Properties.Settings.Default.enableUptime = uptimeCheckBox.Checked;
            Properties.Settings.Default.enableTitle = titleCheckBox.Checked;
            Properties.Settings.Default.enableLinkTitles = linkCheckBox.Checked;
            Properties.Settings.Default.enableYeahBoi = linkCheckBox.Checked;
            Properties.Settings.Default.enableDiscord = discordCheckBox.Checked;
            if (discordCheckBox.Checked)
            {
                Properties.Settings.Default.discordServer = discordTextBox.Text;
            }
            Properties.Settings.Default.Save();
            Close();
        }

        private void prefixTextBox_TextChanged(object sender, EventArgs e)
        {
            updateSaveButton();
        }

        private void discordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            discordTextBox.Enabled = discordCheckBox.Checked;
            updateSaveButton();
        }

        private void discordTextBox_TextChanged(object sender, EventArgs e)
        {
            updateSaveButton();
        }

        private void updateSaveButton()
        {
            if (prefixTextBox.Text.Length == 0
                || (discordCheckBox.Checked && discordTextBox.Text == ""))
            {
                saveButton.Enabled = false;
            }
            else
            {
                saveButton.Enabled = true;
            }
        }
    }
}
