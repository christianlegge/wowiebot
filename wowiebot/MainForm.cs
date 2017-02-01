using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wowiebot
{
    public partial class MainForm : Form
    {
        public string loggedInUser = null;
        public string loggedInOauth = null;
        private OAuthForm childLoginBox = null;
        private bool connected = false;
        private Timer dcTimer = new Timer();

        public MainForm()
        {
            InitializeComponent();

            dcTimer.Tick += disconnectAction;
            dcTimer.Interval = 1500;
            channelTextBox.Text = Properties.Settings.Default.prevChannel;
            if (Properties.Settings.Default.userCookie != "" && Properties.Settings.Default.oauthCookie != "")
            {
                useWowieBox.Checked = false;
                loggedInUser = Properties.Settings.Default.userCookie;
                loggedInOauth = Properties.Settings.Default.oauthCookie;
                updateConnectButton();
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
                Task connectTask = new Task(new Action(connectTask_fn));
                connectTask.Start();
                connectButton.Text = "Disconnect";
                connected = true;
                loginPopoutButton.Enabled = false;
                channelTextBox.Enabled = false;
                useWowieBox.Enabled = false;
                configButton.Enabled = false;
                Properties.Settings.Default.prevChannel = channelTextBox.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                chatrig.chatrig.disconnect();
                connected = false;
                connectButton.Enabled = false;
                dcTimer.Start();
            }
        }

        private void connectTask_fn()
        {
            chatrig.chatrig.runBot(channelTextBox.Text, loggedInUser, loggedInOauth);
        }

        private void disconnectAction(object sender, EventArgs e)
        {
            loginPopoutButton.Enabled = true;
            channelTextBox.Enabled = true;
            useWowieBox.Enabled = true;
            configButton.Enabled = true;
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
            FunctionsForm funcForm = new FunctionsForm();
            funcForm.StartPosition = FormStartPosition.CenterParent;
            funcForm.ShowDialog();
        }
    }
}
