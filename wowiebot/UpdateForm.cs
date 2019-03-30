using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using System.Net;
using System.Windows.Forms;

namespace wowiebot
{
    public partial class UpdateForm : Form
    {
        string downloadUrl;

        public UpdateForm()
        {
            InitializeComponent();
        }

        public UpdateForm(string url)
        {
            InitializeComponent();
            downloadUrl = url;
        }

        private void DownloadProgressForm_Load(object sender, EventArgs e)
        {

            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                wc.DownloadFileAsync(new System.Uri(downloadUrl),
                "wowiebot.exe.new");
            }
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C ping 127.0.0.1 -n 4 && cd \"" + Application.StartupPath + "\" && del wowiebot.exe && ren wowiebot.exe.new wowiebot.exe && wowiebot.exe";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Elapsed += T_Elapsed;
            t.Start();
            Process.Start(Info);
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            Application.Exit();
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
    }
}
