using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace wowiebot
{
    class WowiebotApplication
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Could not load"))
                {
                    MessageBox.Show("Error starting application! Missing libraries? Redownload the application from GitHub to ensure you have the latest.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Unknown error! Please report this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
