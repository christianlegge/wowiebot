﻿using System;
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
        public event EventHandler VideoFinished;
        public event EventHandler PlayerReady;

        string playVideoScript = @"playVideo('{0}');";
        string stopVideoScript = @"stopVideo();";

        public BrowserControl()
        {
            InitializeComponent();

            browser = new ChromiumWebBrowser()
            {
                Size = new Size(310, 210),
            };
            
            browser.LoadHtml(File.ReadAllText(@".\player.html"));

            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            browser.RegisterAsyncJsObject("boundAsync", this);

            this.Controls.Add(browser);
        }

        public void playVideo(string id)
        {
            browser.GetMainFrame().EvaluateScriptAsync(String.Format(playVideoScript, id));
        }

        public void videoFinished()
        {
            VideoFinished(this, null);
        }

        internal void stopVideo()
        {
            browser.GetMainFrame().EvaluateScriptAsync(stopVideoScript);
            VideoFinished(this, null);
        }
        public void playerReady()
        {
            PlayerReady(this, null);
        }
    }

    public class BoundJsHandler
    {
        public void videoFinished()
        {
            MessageBox.Show("a");
        }
        public void playerReady()
        {

        }
    }
}