using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Google.Apis.YouTube.v3;

namespace wowiebot
{
    public partial class SongRequestForm : Form
    {
        BrowserControl browser;
        public event EventHandler VideoFinished;
        public bool songIsPlaying = false;

        public SongRequestForm()
        {
            InitializeComponent();

            songRequestQueueControl1.setParent(this);

            playNextButton.Enabled = false;
      //      queueButton.Enabled = false;

            AppDomain.CurrentDomain.AssemblyResolve += Resolver;

            LoadApp();

            browser = new BrowserControl()
            {
                Size = new Size(400, 225),
                Location = new Point(20, 20),
            };
            browser.VideoFinished += Browser_VideoFinished;
            browser.PlayerReady += Browser_PlayerReady;
            this.Controls.Add(browser);
        }

        private void Browser_PlayerReady(object sender, EventArgs e)
        {
            VoidVoidDelegate d = delegate
            {
     //           queueButton.Enabled = true;
            };
            this.Invoke(d);
        }

        private void Browser_VideoFinished(object sender, EventArgs e)
        {
            songIsPlaying = false;
            VideoFinished(this, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void LoadApp()
        {
            var settings = new CefSettings();

            // Set BrowserSubProcessPath based on app bitness at runtime
            settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                   Environment.Is64BitProcess ? "x64" : "x86",
                                                   "CefSharp.BrowserSubprocess.exe");

            // Make sure you set performDependencyCheck false
            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);

      
        }

        internal void playNext()
        {
            
        }

        // Will attempt to load missing assembly from either x86 or x64 subdir
        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                       Environment.Is64BitProcess ? "x64" : "x86",
                                                       assemblyName);

                return File.Exists(archSpecificPath)
                           ? Assembly.LoadFile(archSpecificPath)
                           : null;
            }

            return null;
        }

        internal void setSkipEnabled(bool v)
        {
            playNextButton.Enabled = v;
        }

        private void queueButton_Click(object sender, EventArgs e)
        {
   //         songRequestQueueControl1.queueSong(toQueueTextBox.Text);
        }

        public void playVideo(string id)
        {
            songIsPlaying = true;
            browser.playVideo(id);
        }

        public bool isAutoplayOn()
        {
            return autoplayCheckBox.Checked;
        }

        public void queueSong(SongRequest sr)
        {
            songRequestQueueControl1.queueSong(sr);
        }

        delegate void VoidVoidDelegate();

        private void playNextButton_Click(object sender, EventArgs e)
        {
            if (!songIsPlaying)
            {
                songRequestQueueControl1.playNext();
            }
            else
            {
                browser.stopVideo();
            }
        }
    }

}
