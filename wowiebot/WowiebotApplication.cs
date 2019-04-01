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

            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
