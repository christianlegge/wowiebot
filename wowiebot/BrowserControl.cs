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
        public static string script = @"var tag = document.createElement('script');


      tag.src = ""https://www.youtube.com/iframe_api"";
      var firstScriptTag = document.getElementsByTagName('script')[0];
            firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

            // 3. This function creates an <iframe> (and YouTube player)
            //    after the API code downloads.
            var player;
            function onYouTubeIframeAPIReady()
            {
                player = new YT.Player('player', {
            videoId: 'M7lc1UVf-VE',
          events:
            {
                'onReady': onPlayerReady,
            'onStateChange': onPlayerStateChange
          }
        });
      }

    // 4. The API will call this function when the video player is ready.
    function onPlayerReady(event)
    {
        event.target.playVideo();
    }

    // 5. The API calls this function when the player's state changes.
    //    The function indicates that when playing a video (state=1),
    //    the player should play for six seconds and then stop.
    var done = false;
    function onPlayerStateChange(event)
    {
        if (event.data == YT.PlayerState.ENDED && !done) {
        (async function() {
                await CefSharp.BindObjectAsync(""boundAsync"", ""bound"");

                boundAsync.showMessage('Message from JS');
            })();
            /*setTimeout(stopVideo, 6000);
            done = true;*/
        }
    }
    function stopVideo()
    {
        player.stopVideo();
        (async function() {
        await CefSharp.BindObjectAsync(""boundAsync"", ""bound"");

        boundAsync.showMessage('Message from JS');
    })();
    }";

        public BrowserControl(string url)
        {
            InitializeComponent();

            browser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill,
            };
            
           // browser.RenderProcessMessageHandler = new RenderProcessMessageHandler();
            //Wait for the page to finish loading (all resources will have been loaded, rendering is likely still happening)
            browser.LoadingStateChanged += (sender, args) =>
            {
                //Wait for the Page to finish loading
                if (args.IsLoading == false)
                {
                    browser.GetMainFrame().ExecuteJavaScriptAsync(BrowserControl.script);
                }
            };
            
            //Wait for the MainFrame to finish loading
                        browser.FrameLoadEnd += (sender, args) =>
            {
                //Wait for the MainFrame to finish loading
                if (args.Frame.IsMain)
                {
                 //   args.Frame.ExecuteJavaScriptAsync("alert('MainFrame finished loading');");
                }
            };

            //CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            //browser.RegisterJsObject("PlayerEvent", new cShaarp_Js());

            browser.JavascriptObjectRepository.Register("boundAsync", new cShaarp_Js(), true);

            this.Controls.Add(browser);
        }


    }

    public class cShaarp_Js
    {
        public void showMessage(string msg) {
            MessageBox.Show(msg);
        }
    }
}
