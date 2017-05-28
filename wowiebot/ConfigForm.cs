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
    public partial class ConfigForm : Form
    {
        DataTable commandsDataTable;
        Size oldSize;

        public ConfigForm()
        {
            InitializeComponent();
            prefixTextBox.Text = Properties.Settings.Default.prefix;
            linkCheckBox.Checked = Properties.Settings.Default.enableLinkTitles;
            updateSaveButton();
            commandsDataTable = getDataTableFromSettings();
            
            
            
            dataGridView1.DataSource = commandsDataTable;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.prefix = prefixTextBox.Text;
            Properties.Settings.Default.enableLinkTitles = linkCheckBox.Checked;
            string test = JsonConvert.SerializeObject(dataGridView1.DataSource);
            Properties.Settings.Default.commandsDataTableJson = JsonConvert.SerializeObject(dataGridView1.DataSource);
            Properties.Settings.Default.Save();
            Close();
        }

        private void prefixTextBox_TextChanged(object sender, EventArgs e)
        {
            updateSaveButton();
        }

        private void updateSaveButton()
        {
            if (prefixTextBox.Text.Length == 0)
            {
                saveButton.Enabled = false;
            }
            else
            {
                saveButton.Enabled = true;
            }
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
                ((MainForm)ParentForm).loadDefaultCommandsTable();
            }
            return JsonConvert.DeserializeObject<DataTable>(Properties.Settings.Default.commandsDataTableJson);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommandsHelpForm commandsHelpForm = new CommandsHelpForm();
            commandsHelpForm.Show();
        }
    }
}
