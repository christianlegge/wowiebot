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

        public SongRequestQueueControl()
        {
            InitializeComponent();
            
            q = new SongRequestQueue();
            q.QueueChanged += Q_QueueChanged;
        }

        public void setParent(SongRequestForm p)
        {
            parentForm = p;
            parentForm.VideoFinished += ParentForm_VideoFinished;
        }

        private void ParentForm_VideoFinished(object sender, EventArgs e)
        {
            if (q.songFinished() != null && parentForm.isAutoplayOn())
            {
                playNext();
            }
        }

        internal void firstRemoved()
        {
            parentForm.firstRemoved();
        }

        public void queueSong(SongRequest sr)
        {
            q.queueSong(sr);
            if (q.Count() == 1 && parentForm.isAutoplayOn())
            {
                playNext();
            }
        }

        internal void removeSong(SongRequest songRequest)
        {
            q.removeSong(songRequest);
        }

        public void queueSong(string srString, string requester)
        {
            queueSong(new SongRequest(srString, requester));
        }

        private void Q_QueueChanged(object sender, EventArgs e)
        {
            VoidVoidDelegate d = delegate
            {
                foreach (SongRequestControl src in srControls)
                {
                    Controls.Remove(src);
                }
                int height = 0;
                foreach (SongRequest sr in q)
                {
                    SongRequestControl src = new SongRequestControl(sr, this);
                    src.Location = new Point(0, height);
                    height = height + src.Height;
                    Controls.Add(src);
                    srControls.Add(src);
                }
                if (!parentForm.songIsPlaying && parentForm.isAutoplayOn() && q.Count() >= 1)
                {
                    parentForm.playNext();
                }
                parentForm.setSkipEnabled(q.Count() > 0);
            };
            this.Invoke(d);
        }

        public void playNext()
        {
            parentForm.playVideo(q.First().id);
        }

        internal SongRequest First()
        {
            return q.First();
        }

        delegate void VoidVoidDelegate();
    }
}
