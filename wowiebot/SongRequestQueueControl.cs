using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wowiebot
{
    public partial class SongRequestQueueControl : UserControl
    {
        SongRequestQueue q;
        List<SongRequestControl> srControls = new List<SongRequestControl>();
        SongRequestForm parentForm;

        public SongRequestQueueControl(SongRequestForm parent)
        {
            InitializeComponent();

            parentForm = parent;
            q = new SongRequestQueue();
            q.QueueChanged += Q_QueueChanged;
        }

        public void queueSong(SongRequest sr)
        {
            q.queueSong(sr);
            parentForm.playVideo(sr.id);
        }

        public void queueSong(string srString)
        {
            queueSong(new SongRequest(srString));
        }

        private void Q_QueueChanged(object sender, EventArgs e)
        {
            foreach (SongRequestControl src in srControls)
            { 
                Controls.Remove(src);
            }
            int height = 0;
            foreach (SongRequest sr in q)
            {
                SongRequestControl src = new SongRequestControl(sr, q);
                src.Location = new Point(0, height);
                height = height + src.Height;
                Controls.Add(src);
                srControls.Add(src);
            }
        }
    }
}
