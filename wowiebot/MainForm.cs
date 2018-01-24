using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace wowiebot
{

    public partial class MainForm : Form
    {
        private const string thisVersion = "v2.2";
        private string latestVersion;
        private JObject releaseJson;

        public string loggedInUser = null;
        public string loggedInOauth = null;
        private OAuthForm childLoginBox = null;
        private bool connected = false;
        private Timer dcTimer = new Timer();
        delegate void SetTextCallback(string text);
        private bool connecting = false;

        public void writeToServerOutputTextBox(string text)
        {
            if (this.serverOutTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(writeToServerOutputTextBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                serverOutTextBox.AppendText(text);
            }
        }

        public MainForm()
        {
            InitializeComponent();


            dcTimer.Tick += disconnectAction;
            dcTimer.Interval = 1500;
            channelTextBox.Text = Properties.Settings.Default.prevChannel;
            serverOutTextBox.TextChanged += ServerOutTextBox_TextChanged;

            if (Properties.Settings.Default.userCookie != "" && Properties.Settings.Default.oauthCookie != "")
            {
                useWowieBox.Checked = false;
                loggedInUser = Properties.Settings.Default.userCookie;
                loggedInOauth = Properties.Settings.Default.oauthCookie;
                updateConnectButton();
            }
            if (Properties.Settings.Default.commandsDataTableJson == null || Properties.Settings.Default.commandsDataTableJson == "" || Properties.Settings.Default.commandsDataTableJson == "[]")
            {
                loadDefaultCommandsTable();
            }

            if (Properties.Settings.Default.periodicMessagesDataTableJson == null || Properties.Settings.Default.periodicMessagesDataTableJson == "" || Properties.Settings.Default.periodicMessagesDataTableJson == "[]")
            {
                loadDefaultPeriodicMessagesTable();
            }

            loginPopoutButton.Enabled = !useWowieBox.Checked;

            connectButton.Enabled = channelTextBox.TextLength >= 4;

            if (useWowieBox.Checked)
            {
                loggedInUser = "wowiebot";
                loggedInOauth = "5bdocznijbholgvt3o9u6t5ui6okjs";
                updateConnectButton();

            }
        }

        public void loadDefaultCommandsTable()
        {
            // return default table
            DataTable table = new DataTable();
            DataColumn enabled = new DataColumn("Enabled", typeof(bool));
            DataColumn cmd = new DataColumn("Command");
            DataColumn msg = new DataColumn("Message");
            DataColumn showInHelp = new DataColumn("Show in commands list", typeof(bool));

            table.Columns.Add(enabled);
            table.Columns.Add(cmd);
            table.Columns.Add(msg);
            table.Columns.Add(showInHelp);
            DataRow quoteRow = table.NewRow();
            DataRow addquoteRow = table.NewRow();
            DataRow voteyesRow = table.NewRow();
            DataRow titleRow = table.NewRow();
            DataRow uptimeRow = table.NewRow();
            DataRow discordRow = table.NewRow();
            DataRow eightBallRow = table.NewRow();
            DataRow calculatorRow = table.NewRow();
            DataRow helpRow = table.NewRow();

            quoteRow.SetField<bool>(enabled, true);
            quoteRow.SetField<string>(cmd, "quote");
            quoteRow.SetField<string>(msg, "[$QNUM]: $QUOTE");
            quoteRow.SetField<bool>(showInHelp, true);
            addquoteRow.SetField<bool>(enabled, true);
            addquoteRow.SetField<string>(cmd, "addquote");
            addquoteRow.SetField<string>(msg, "$ADDQUOTE");
            addquoteRow.SetField<bool>(showInHelp, true);
            voteyesRow.SetField<bool>(enabled, true);
            voteyesRow.SetField<string>(cmd, "yes");
            voteyesRow.SetField<string>(msg, "$VOTEYES");
            voteyesRow.SetField<bool>(showInHelp, false);
            titleRow.SetField<bool>(enabled, true);
            titleRow.SetField<string>(cmd, "title");
            titleRow.SetField<string>(msg, "$BROADCASTER is playing $GAME: \"$TITLE\"");
            titleRow.SetField<bool>(showInHelp, true);
            uptimeRow.SetField<bool>(enabled, true);
            uptimeRow.SetField<string>(cmd, "uptime");
            uptimeRow.SetField<string>(msg, "$BROADCASTER has been live for $UPHOURS hours and $UPMINUTES minutes.");
            uptimeRow.SetField<bool>(showInHelp, true);
            discordRow.SetField<bool>(enabled, true);
            discordRow.SetField<string>(cmd, "discord");
            discordRow.SetField<string>(msg, "Join my discord server! http://discord.gg/XXXXXX");
            discordRow.SetField<bool>(showInHelp, true);
            eightBallRow.SetField<bool>(enabled, true);
            eightBallRow.SetField<string>(cmd, "8ball");
            eightBallRow.SetField<string>(msg, "$8BALL");
            eightBallRow.SetField<bool>(showInHelp, true);
            calculatorRow.SetField<bool>(enabled, true);
            calculatorRow.SetField<string>(cmd, "calc");
            calculatorRow.SetField<string>(msg, "Answer: $CALCULATOR");
            calculatorRow.SetField<bool>(showInHelp, false);
            helpRow.SetField<bool>(enabled, true);
            helpRow.SetField<string>(cmd, "help");
            helpRow.SetField<string>(msg, "Use me in the following ways: $COMMANDS");
            helpRow.SetField<bool>(showInHelp, false);
            table.Rows.Add(quoteRow);
            table.Rows.Add(addquoteRow);
            table.Rows.Add(voteyesRow);
            table.Rows.Add(titleRow);
            table.Rows.Add(uptimeRow);
            table.Rows.Add(discordRow);
            table.Rows.Add(eightBallRow);
            table.Rows.Add(calculatorRow);
            table.Rows.Add(helpRow);
            String x = JsonConvert.SerializeObject(table);
            Properties.Settings.Default.commandsDataTableJson = x;
            Properties.Settings.Default.Save();
            DataTable test = JsonConvert.DeserializeObject<DataTable>(x);
        }

        public void loadDefaultPeriodicMessagesTable()
        {
            // return default table
            DataTable table = new DataTable();
            DataColumn enabled = new DataColumn("Enabled", typeof(bool));
            DataColumn msg = new DataColumn("Message");
            DataColumn period = new DataColumn("Period", typeof(double));
            DataColumn offset = new DataColumn("Offset", typeof(double));

            table.Columns.Add(enabled);
            table.Columns.Add(msg);
            table.Columns.Add(period);
            table.Columns.Add(offset);
            DataRow discordRow = table.NewRow();
            DataRow twitterRow = table.NewRow();
            discordRow.SetField<bool>(enabled, true);
            discordRow.SetField<string>(msg, "Like this bot? You can get it for yourself! https://github.com/scatterclegge/wowiebot/releases");
            discordRow.SetField<double>(period, 30);
            discordRow.SetField<double>(offset, 0);
            twitterRow.SetField<bool>(enabled, true);
            twitterRow.SetField<string>(msg, "Be sure to leave a follow if you're enjoying the stream!");
            twitterRow.SetField<double>(period, 30);
            twitterRow.SetField<double>(offset, 15);
            table.Rows.Add(discordRow);
            table.Rows.Add(twitterRow);
            String x = JsonConvert.SerializeObject(table);
            Properties.Settings.Default.periodicMessagesDataTableJson = x;
            Properties.Settings.Default.Save();
            DataTable test = JsonConvert.DeserializeObject<DataTable>(x);
        }

        private void ServerOutTextBox_TextChanged(object sender, EventArgs e)
        {
            if (serverOutTextBox.Text.Contains("Welcome, GLHF!") && connecting)
            {
                connecting = false;
                connectButton.Enabled = true;
                connectButton.Text = "Disconnect";
            }
        }

        private void ChildLoginBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateConnectButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            childLoginBox = new OAuthForm(this);
            childLoginBox.FormClosed += ChildLoginBox_FormClosed;
            childLoginBox.StartPosition = FormStartPosition.CenterParent;
            childLoginBox.ShowDialog();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                writeToServerOutputTextBox("Starting connection.\r\n\r\n");
                connecting = true;
                Task connectTask = new Task(new Action(connectTask_fn));

                connectTask.Start();

                connected = true;
                loginPopoutButton.Enabled = false;
                channelTextBox.Enabled = false;
                useWowieBox.Enabled = false;
                connectButton.Enabled = false;
                configButton.Enabled = false;
                updateButton.Enabled = false;
                Properties.Settings.Default.prevChannel = channelTextBox.Text;
                Properties.Settings.Default.Save();

            }
            else
            {
                ChatHandler.disconnect();
                connected = false;
                connectButton.Enabled = false;
                writeToServerOutputTextBox("\r\nDisconnected.\r\n\r\n");
                dcTimer.Start();
            }
        }

        private void connectTask_fn()
        {

            int retVal = 999;
            try
            {
                retVal = ChatHandler.start(this, channelTextBox.Text, loggedInUser, loggedInOauth);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception thrown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (retVal == 1)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    connected = false;
                    connecting = false;
                    loginPopoutButton.Enabled = !useWowieBox.Checked;
                    channelTextBox.Enabled = true;
                    useWowieBox.Enabled = true;
                    configButton.Enabled = true;
                    updateButton.Enabled = true;
                    updateConnectButton();
                });

            }
        }

        private void disconnectAction(object sender, EventArgs e)
        {
            loginPopoutButton.Enabled = !useWowieBox.Checked;
            channelTextBox.Enabled = true;
            useWowieBox.Enabled = true;
            configButton.Enabled = true;
            updateButton.Enabled = true;
            updateConnectButton();
            dcTimer.Stop();
        }

        private void useWowieBox_CheckedChanged(object sender, EventArgs e)
        {
            loginPopoutButton.Enabled = !useWowieBox.Checked;
            if (!useWowieBox.Checked)
            {
                if (Properties.Settings.Default.userCookie != "" && Properties.Settings.Default.oauthCookie != "")
                {
                    useWowieBox.Checked = false;
                    loggedInUser = Properties.Settings.Default.userCookie;
                    loggedInOauth = Properties.Settings.Default.oauthCookie;
                }
                else
                {
                    loggedInUser = null;
                    loggedInOauth = null;
                }
                updateConnectButton();
            }
            else
            {
                loggedInUser = "wowiebot";
                loggedInOauth = "5bdocznijbholgvt3o9u6t5ui6okjs";
                updateConnectButton();
            }
        }

        private void channelTextBox_TextChanged(object sender, EventArgs e)
        {
            updateConnectButton();
        }

        private void updateConnectButton()
        {
            if (loggedInUser != null && loggedInOauth != null)
            {
                connectButton.Text = "Connect as " + loggedInUser;
                connectButton.Enabled = channelTextBox.TextLength >= 4;
            }
            else
            {
                connectButton.Text = "Connect";
                connectButton.Enabled = false;
            }
        }

        private void configButton_Click(object sender, EventArgs e)
        {
            ConfigForm funcForm = new ConfigForm();
            funcForm.StartPosition = FormStartPosition.CenterParent;
            funcForm.ShowDialog();
        }

        private void checkForUpdates()
        {
            HttpWebRequest apiRequest = (HttpWebRequest)WebRequest.Create("https://api.github.com/repos/scatterclegge/wowiebot/releases/latest");
            apiRequest.Accept = "application/vnd.github.v3+json";
            apiRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";

            Stream apiStream;

            apiStream = apiRequest.GetResponse().GetResponseStream();
            StreamReader apiReader = new StreamReader(apiStream);
            string jsonData = apiReader.ReadToEnd();
            releaseJson = JObject.Parse(jsonData);
            latestVersion = releaseJson.Property("tag_name").Value.ToString();
            updateButton.Visible = latestVersion != thisVersion;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            checkForUpdates();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("There is an update to wowiebot!\n\nLatest version: " + latestVersion + "\nThis version: " + thisVersion + "\n\nUpdate? (Will restart automatically.)", "Update!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                JObject exeJson = releaseJson["assets"].Values<JObject>()
                              .Where(m => m["name"].Value<string>() == "wowiebot.exe")
                              .FirstOrDefault();
                string downloadUrl = exeJson["browser_download_url"].ToString();
                UpdateForm dpform = new UpdateForm(downloadUrl);
                dpform.StartPosition = FormStartPosition.CenterScreen;
                dpform.ShowDialog();
            }

        }

    }
}
