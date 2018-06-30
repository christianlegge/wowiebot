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

        public SongRequestQueueControl()
        {
            InitializeComponent();
            q = new SongRequestQueue();
            q.QueueChanged += Q_QueueChanged;
        }

        public void queueSong(SongRequest sr)
        {
            q.queueSong(sr);
        }

        public void queueSong(string srString)
        {
            q.queueSong(new SongRequest(srString));
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
                SongRequestControl src = new SongRequestControl(sr);
                src.Location = new Point(0, height);
                height = height + src.Height;
                Controls.Add(src);
            }
        }
    }
}
