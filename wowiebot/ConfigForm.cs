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
using System.Text.RegularExpressions;
using System.IO;

namespace wowiebot
{
    public partial class ConfigForm : Form
    {
        DataTable commandsDataTable;
        Size oldSize;

        public ConfigForm()
        {
            InitializeComponent();

            quoteMethodDropDown.DataSource = new string[] { "All quotes are added automatically",
                                                            "Only moderators can add quotes",
                                                            "Only the broadcaster can add quotes",
                                                            "Quotes are added after being voted on by chat"};

            prefixTextBox.Text = Properties.Settings.Default.prefix;
            linkCheckBox.Checked = Properties.Settings.Default.enableLinkTitles;
            quoteMethodDropDown.SelectedIndex = Properties.Settings.Default.quoteAddingMethod;
            quoteVotersNum.Value = Properties.Settings.Default.quoteVotersNumber;
            emptyQuoteMessage.Text = Properties.Settings.Default.emptyQuotesMessage;
            noPermsMsgTextBox.Text = Properties.Settings.Default.noPermsMessage;
            updateSaveButton();
            commandsDataTable = getDataTableFromSettings();

            dataGridView1.DataSource = commandsDataTable;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            List<string> dupes = dupeCommands();
            string invalid = invalidCommandIfExists();

            if (quoteMethodDropDown.SelectedIndex == 3 && ((DataTable)dataGridView1.DataSource).Select("Message LIKE '*$VOTEYES*'").Length == 0)
            {
                MessageBox.Show("You need to have a $VOTEYES command if you're adding quotes by voting!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dupes.Count > 0)
            {
                MessageBox.Show("You have duplicate commands: " + String.Join(", ", dupes), "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (invalid != null)
            {
                MessageBox.Show("You have an invalid command: " + invalid + " \n\nFormat: <name> [ , <alias> [ , <alias> ...", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                Properties.Settings.Default.prefix = prefixTextBox.Text;
                Properties.Settings.Default.enableLinkTitles = linkCheckBox.Checked;
                Properties.Settings.Default.commandsDataTableJson = JsonConvert.SerializeObject(dataGridView1.DataSource);
                Properties.Settings.Default.quoteAddingMethod = quoteMethodDropDown.SelectedIndex;
                Properties.Settings.Default.quoteVotersNumber = (int)quoteVotersNum.Value;
                Properties.Settings.Default.emptyQuotesMessage = emptyQuoteMessage.Text;
                Properties.Settings.Default.noPermsMessage = noPermsMsgTextBox.Text;
                Properties.Settings.Default.Save();
                Close();
            }
        }

        private string invalidCommandIfExists()
        {
            List<string> cmds = new List<string>();
            Regex r = new Regex(@"^\w+(?:\s*,\s*\w+\s*)*$"); 
            foreach (DataRow row in ((DataTable)dataGridView1.DataSource).Rows)
            {
                string s = row["Command"].ToString();
                Match m = r.Match(s);
                if (!m.Success)
                {
                    return s;
                }
            }
            return null;
        }

        private List<string> dupeCommands()
        {
            List<string> cmds = new List<string>();
            foreach(DataRow row in ((DataTable)dataGridView1.DataSource).Rows)
            {
                cmds.Add((string)row["Command"].ToString().ToLower());
            }
            var duplicates = cmds.GroupBy(x => x)
                             .Where(g => g.Count() > 1)
                             .Select(g => g.Key)
                             .ToList();
            return duplicates;
        }

        private void prefixTextBox_TextChanged(object sender, EventArgs e)
        {
            updateSaveButton();
        }

        private void updateSaveButton()
        {
            if (prefixTextBox.Text.Length == 0 || emptyQuoteMessage.Text.Length == 0)
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

        private void quoteMethodDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (quoteMethodDropDown.SelectedIndex == 3)
            {
                // voting
                quoteVotersNum.Enabled = true;
            }
            else
            {
                quoteVotersNum.Enabled = false;
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Show in commands list"].Value = false;
        }

        private void emptyQuoteMessage_TextChanged(object sender, EventArgs e)
        {
            updateSaveButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PeriodicMessagesForm periodicForm = new PeriodicMessagesForm();
            periodicForm.StartPosition = FormStartPosition.CenterScreen;
            periodicForm.ShowDialog();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            WowiebotSettings ws = new WowiebotSettings();
            ws.loadFromSettings();
            ws.id = "YesImWowiebotSettings";
            string jsonSettings = JsonConvert.SerializeObject(ws);

            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = "wowiebot_settings.json";
            fd.Filter = "JSON text (*.json)|*.json|All files (*.*)|*.*";
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(fd.FileName))
                {
                    sw.Write(jsonSettings);
                }
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            string jsonSettings;
            OpenFileDialog fd = new OpenFileDialog();
            fd.FileName = "wowiebot_settings.json";
            fd.Filter = "JSON text (*.json)|*.json|All files (*.*)|*.*";
            DialogResult result = fd.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(fd.FileName))
                {
                    jsonSettings = sr.ReadToEnd();
                }

                try
                {
                    var settings = JsonConvert.DeserializeObject<WowiebotSettings>(jsonSettings);

                    if (MessageBox.Show("You will permanently lose all your current settings as they will be overwritten with the imported ones! Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        settings.saveToSettings();
                        this.Close();
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Error importing settings! No data was lost.");
                }
            }
        }
    }
}
