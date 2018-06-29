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

namespace wowiebot
{
    public partial class BrowserControl : UserControl
    {
        ChromiumWebBrowser browser;

        public BrowserControl(string url)
        {
            InitializeComponent();
            InitializeComponent();

            browser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill,
            };

            browser.JavascriptObjectRepository.Register("player", new cShaarp_Js());



            this.Controls.Add(browser);
        }
    }

    public class cShaarp_Js
    {
        public void onPlayerStateChange(Object o) {
            MessageBox.Show("test");
        }
    }
}
