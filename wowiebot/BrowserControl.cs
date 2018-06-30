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
using CefSharp.ModelBinding;

namespace wowiebot
{
    public partial class BrowserControl : UserControl
    {
        ChromiumWebBrowser browser;

        string playVideoScript = @"playVideo('{0}');";

        public BrowserControl(string url)
        {
            InitializeComponent();

            browser = new ChromiumWebBrowser()
            {
                Size = new Size(310, 210),
            };
            
            browser.LoadHtml(File.ReadAllText(@".\player.html"));

            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            browser.RegisterAsyncJsObject("boundAsync", new BoundJsHandler());

            this.Controls.Add(browser);
        }

        public void playVideo(string id)
        {
            browser.GetMainFrame().EvaluateScriptAsync(String.Format(playVideoScript, id));
        }


    }

    public class BoundJsHandler
    {
        public void videoFinished()
        {
            MessageBox.Show("Video finished");
        }
    }
}
