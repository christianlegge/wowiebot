using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace wowiebot
{
    enum BotFunction { ShowQuote, AddQuote, SendMessage, ShowUptime, ShowTitle};

    public partial class ConfigForm : Form
    {
        DataTable commandsDataTable;

        public ConfigForm()
        {
            InitializeComponent();
            discordTextBox.Enabled = discordCheckBox.Checked;
            prefixTextBox.Text = Properties.Settings.Default.prefix;
            quoteCheckBox.Checked = Properties.Settings.Default.enableQuotes;
            editQuotesButton.Enabled = Properties.Settings.Default.enableQuotes;
            uptimeCheckBox.Checked = Properties.Settings.Default.enableUptime;
            titleCheckBox.Checked = Properties.Settings.Default.enableTitle;
            linkCheckBox.Checked = Properties.Settings.Default.enableLinkTitles;
            discordCheckBox.Checked = Properties.Settings.Default.enableDiscord;
            eightBallCheckBox.Checked = Properties.Settings.Default.enable8Ball;
            if (Properties.Settings.Default.enableDiscord)
            {
                discordTextBox.Text = Properties.Settings.Default.discordServer;
            }
            else
            {
                discordTextBox.Text = "https://";
            }
            updateSaveButton();
            commandsDataTable = getDataTableFromSettings();
            
            dataGridView1.DataSource = commandsDataTable;
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
            Properties.Settings.Default.enableDiscord = discordCheckBox.Checked;
            Properties.Settings.Default.enable8Ball = eightBallCheckBox.Checked;
            if (discordCheckBox.Checked)
            {
                Properties.Settings.Default.discordServer = discordTextBox.Text;
            }
            string test = JsonConvert.SerializeObject(dataGridView1.DataSource);
            Properties.Settings.Default.commandsDataTableJson = JsonConvert.SerializeObject(dataGridView1.DataSource);
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

        private void quoteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            editQuotesButton.Enabled = quoteCheckBox.Checked;
        }

        private void editQuotesButton_Click(object sender, EventArgs e)
        {
            EditStringsForm quotesForm = new EditStringsForm("quotes");
            quotesForm.StartPosition = FormStartPosition.CenterScreen;
            quotesForm.ShowDialog();
        }

        private void edit8BallChoicesButton_Click(object sender, EventArgs e)
        {
            EditStringsForm quotesForm = new EditStringsForm("choices");
            quotesForm.StartPosition = FormStartPosition.CenterScreen;
            quotesForm.ShowDialog();
        }

        private DataTable getDataTableFromSettings()
        {
            if (Properties.Settings.Default.commandsDataTableJson == null || Properties.Settings.Default.commandsDataTableJson == "" || Properties.Settings.Default.commandsDataTableJson == "[]")
            {
                // return default table
                DataTable table = new DataTable();
                DataColumn cmd = new DataColumn("Command");
                DataColumn fn = new DataColumn("Function");
                DataColumn parm = new DataColumn("Parameters");
                table.Columns.Add(cmd);
                table.Columns.Add(fn);
                table.Columns.Add(parm);
                DataRow quoteRow = table.NewRow();
                DataRow titleRow = table.NewRow();
                DataRow uptimeRow = table.NewRow();
                DataRow discordRow = table.NewRow();
                DataRow eightBallRow = table.NewRow();
                quoteRow.SetField<string>(cmd, "quote");
                quoteRow.SetField<BotFunction>(fn, BotFunction.SendMessage);
                quoteRow.SetField<string>(parm, "[$QUOTENUM]: $QUOTE");
                titleRow.SetField<string>(cmd, "title");
                titleRow.SetField<BotFunction>(fn, BotFunction.SendMessage);
                titleRow.SetField<string>(parm, "$BROADCASTER is playing $GAME: \"$TITLE\"");
                uptimeRow.SetField<string>(cmd, "uptime");
                uptimeRow.SetField<BotFunction>(fn, BotFunction.SendMessage);
                uptimeRow.SetField<string>(parm, "$BROADCASTER has been live for $UPTIME.");
                discordRow.SetField<string>(cmd, "discord");
                discordRow.SetField<BotFunction>(fn, BotFunction.SendMessage);
                discordRow.SetField<string>(parm, "Join my discord server! http://discord.gg/XXXXXX");
                eightBallRow.SetField<string>(cmd, "8ball");
                eightBallRow.SetField<BotFunction>(fn, BotFunction.SendMessage);
                eightBallRow.SetField<string>(parm, "$8BALL");
                table.Rows.Add(quoteRow);
                table.Rows.Add(titleRow);
                table.Rows.Add(uptimeRow);
                table.Rows.Add(discordRow);
                table.Rows.Add(eightBallRow);
                String x = JsonConvert.SerializeObject(table);
                Properties.Settings.Default.commandsDataTableJson = x;
                Properties.Settings.Default.Save();
                DataTable test = JsonConvert.DeserializeObject<DataTable>(x);
                return table;
            }
            return JsonConvert.DeserializeObject<DataTable>(Properties.Settings.Default.commandsDataTableJson);
            
        }
    }
}
