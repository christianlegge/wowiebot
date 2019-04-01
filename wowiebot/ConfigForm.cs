using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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

            githubLink.Links.Add(0, githubLink.Text.Length, "https://github.com/scatter-dev/wowiebot");

            prefixTextBox.Text = Properties.Settings.Default.prefix;
            quoteVotersNum.Value = Properties.Settings.Default.quoteVotersNumber;
            emptyQuoteMessage.Text = Properties.Settings.Default.emptyQuotesMessage;
            noPermsMsgTextBox.Text = Properties.Settings.Default.noPermsMessage;
            messageOnCheerBox.Text = Properties.Settings.Default.messageForBits;
            //bitsMessageThresholdBox.Value = Properties.Settings.Default.bitsMessageThreshold;
            periodicPeriodPicker.Value = Properties.Settings.Default.periodicMessagePeriod;
            periodicSpamPrevent.Value = Properties.Settings.Default.minimumMessagesBetweenPeriodic;
            linkResponseBox.Text = Properties.Settings.Default.linkResponse;
            empty8ballResponseBox.Text = Properties.Settings.Default.empty8BallResponse;
            subResponseBox.Text = Properties.Settings.Default.subResponse;
            giftSubResponse.Text = Properties.Settings.Default.giftSubResponse;
            raidResponse.Text = Properties.Settings.Default.raidResponse;
            closedSrResponse.Text = Properties.Settings.Default.closedSrWindowResponse;
            nonEmbeddableResponse.Text = Properties.Settings.Default.nonEmbeddableSrResponse;
            quoteFailResponse.Text = Properties.Settings.Default.quoteTimerElapsedResponse;
            foreach (string s in Properties.Settings.Default.quotes)
            {
                quotesTextBox.Text += s + "\r\n";
            }
            foreach (string s in Properties.Settings.Default.choices8Ball)
            {
                eightBallBox.Text += s + "\r\n";
            }
            foreach (string s in Properties.Settings.Default.periodicMessagesArray)
            {
                periodicTextBox.Text += s + "\r\n";
            }
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

            if (quoteVotersNum.Value > 0 && ((DataTable)dataGridView1.DataSource).Select("Message LIKE '*$VOTEYES*'").Length == 0)
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
                Properties.Settings.Default.commandsDataTableJson = JsonConvert.SerializeObject(dataGridView1.DataSource);
                Properties.Settings.Default.quoteVotersNumber = (int)quoteVotersNum.Value;
                Properties.Settings.Default.emptyQuotesMessage = emptyQuoteMessage.Text;
                Properties.Settings.Default.noPermsMessage = noPermsMsgTextBox.Text;
                //Properties.Settings.Default.bitsMessageThreshold = (int)bitsMessageThresholdBox.Value;
                Properties.Settings.Default.messageForBits = messageOnCheerBox.Text;
                Properties.Settings.Default.periodicMessagePeriod = (int)periodicPeriodPicker.Value;
                Properties.Settings.Default.minimumMessagesBetweenPeriodic = (int)periodicSpamPrevent.Value;
                Properties.Settings.Default.linkResponse = linkResponseBox.Text;
                Properties.Settings.Default.empty8BallResponse = empty8ballResponseBox.Text;
                Properties.Settings.Default.subResponse = subResponseBox.Text;
                Properties.Settings.Default.giftSubResponse = giftSubResponse.Text;
                Properties.Settings.Default.raidResponse = raidResponse.Text;
                Properties.Settings.Default.closedSrWindowResponse = closedSrResponse.Text;
                Properties.Settings.Default.nonEmbeddableSrResponse = nonEmbeddableResponse.Text;
                Properties.Settings.Default.quoteTimerElapsedResponse = quoteFailResponse.Text;

                System.Collections.Specialized.StringCollection q = new System.Collections.Specialized.StringCollection();
                string[] quotesArr = quotesTextBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < quotesArr.Length; i++)
                {
                    quotesArr[i] = quotesArr[i].Trim();
                }
                quotesArr = quotesArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                q.AddRange(quotesArr);

                System.Collections.Specialized.StringCollection b = new System.Collections.Specialized.StringCollection();
                string[] ballArr = eightBallBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < ballArr.Length; i++)
                {
                    ballArr[i] = ballArr[i].Trim();
                }
                ballArr = ballArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                b.AddRange(ballArr);

                System.Collections.Specialized.StringCollection p = new System.Collections.Specialized.StringCollection();
                string[] periodicArr = periodicTextBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < periodicArr.Length; i++)
                {
                    periodicArr[i] = periodicArr[i].Trim();
                }
                periodicArr = periodicArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                p.AddRange(periodicArr);

                Properties.Settings.Default.quotes = q;
                Properties.Settings.Default.choices8Ball = b;
                Properties.Settings.Default.periodicMessagesArray = p;
                
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
            if (prefixTextBox.Text.Length == 0)
            {
                saveButton.Enabled = false;
            }
            else
            {
                saveButton.Enabled = true;
            }
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

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Show in commands list"].Value = false;
        }

        private void emptyQuoteMessage_TextChanged(object sender, EventArgs e)
        {
            updateSaveButton();
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

        private void addMessageCommandButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Add(new object[] { true, "<command>", "", "<Bot reply here>", true });
            dataGridView1.DataSource = dt;
        }

        private void addQuoteButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Add(new object[] { true, "addquote", "", "$ADDQUOTE", true });
            dataGridView1.DataSource = dt;
        }

        private void getQuoteButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Add(new object[] { true, "quote", "", "[$QNUM]: $QUOTE", true });
            dataGridView1.DataSource = dt;
        }

        private void uptimeButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Add(new object[] { true, "uptime", "", "$BROADCASTER has been live for $UPHOURS hours and $UPMINUTES minutes.", true });
            dataGridView1.DataSource = dt;
        }

        private void eightBallButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Add(new object[] { true, "8ball", "", "The 8-ball says: $8BALL", true });
            dataGridView1.DataSource = dt;
        }

        private void helpCommandAddButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Add(new object[] { true, "help, commands", "", "Available commands: $COMMANDS", true });
            dataGridView1.DataSource = dt;
        }

        private void calculatorButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Add(new object[] { true, "calc, calculate, math", "", "Answer: $CALCULATOR", true });
            dataGridView1.DataSource = dt;
        }

        private void titleGameButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Add(new object[] { true, "title, game", "", "$BROADCASTER is playing $GAME: $TITLE", true });
            dataGridView1.DataSource = dt;
        }

        private void songRequestAddCommand_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Add(new object[] { true, "sr", "", "$SONGREQ", true });
            dataGridView1.DataSource = dt;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Add(new object[] { true, "queue", "", "The total length of the remaining songs in the queue is $QUEUETIME.", true });
            dataGridView1.DataSource = dt;
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }
    }
}
