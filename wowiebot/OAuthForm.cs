using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wowiebot
{
    public partial class OAuthForm : Form
    {
        private Task connectTask;
        private string user;
        private string oauth;
        private MainForm parentForm;

        public OAuthForm(MainForm parent)
        {
            InitializeComponent();
            parentForm = parent;
            oauthLink.Links.Add(0, oauthLink.Text.Length, "https://twitchapps.com/tmi/");
            oauthLink.TabStop = false;
            if (Properties.Settings.Default.userCookie != "" && Properties.Settings.Default.oauthCookie != "")
            {
                rememberBox.Checked = true;
                usernameTextBox.Text = Properties.Settings.Default.userCookie;
                oauthTextBox.Text = Properties.Settings.Default.oauthCookie;
            }

        }

        private void oauthLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void rememberBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["RememberInfo"] = rememberBox.Checked ? "true" : "false";
        }

        private void connectAction()
        {
            TcpClient client = new TcpClient("irc.twitch.tv", 6667);

            NetworkStream stream = client.GetStream();

            string oauth = oauthTextBox.Text;
            string user = usernameTextBox.Text;

            if (oauth.StartsWith("oauth:"))
            {
                oauth = oauth.Substring(6);
            }

            string loginstring = "PASS oauth:" + oauth + "\r\nNICK "+user+"\r\n";
            Byte[] login = System.Text.Encoding.ASCII.GetBytes(loginstring);
            stream.Write(login, 0, login.Length);
            Console.WriteLine("Sent login.\r\n");
            Console.WriteLine(loginstring);
            // Receive the TcpServer.response.
            // Buffer to store the response bytes.
            Byte[] data = new Byte[512];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            stream.Close();
            client.Close();
            if (responseData.Contains("GLHF"))
            {
                this.user = user;
                this.oauth = oauth;
                connectActionEnd(true);
            }
            else
            {
                connectActionEnd(false);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            connectTask = new Task(connectAction);
            connectTask.Start();
            loginButton.Enabled = false;
            cancelButton.Enabled = false;
        }

        private void connectActionEnd(bool success)
        {
            if (success)
            {
                MessageBox.Show("Login successful.");

                this.Invoke((MethodInvoker)delegate
                {
                    if (rememberBox.Checked)
                    {
                        Properties.Settings.Default.userCookie = user;
                        Properties.Settings.Default.oauthCookie = oauth;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.userCookie = "";
                        Properties.Settings.Default.oauthCookie = "";
                        Properties.Settings.Default.Save();
                    }

                    parentForm.loggedInUser = user;
                    parentForm.loggedInOauth = oauth;
                        // close the form on the forms thread
                        this.Close();
                });
            }
            else
            {
                MessageBox.Show("Login failed.");
                this.Invoke((MethodInvoker)delegate
                {
                    // close the form on the forms thread
                    loginButton.Enabled = true;
                    cancelButton.Enabled = true;
                });
            }
        }
    }
}
