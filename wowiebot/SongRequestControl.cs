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
    public partial class SongRequestControl : UserControl
    {
        SongRequest songRequest;
        SongRequestQueue parentQueue;

        public SongRequestControl(SongRequest sr, SongRequestQueue parent)
        {
            InitializeComponent();

            songRequest = sr;
            parentQueue = parent;

            titleLabel.Text = sr.title;
            durationLabel.Text = sr.duration.ToString();
            viewsLabel.Text = sr.views.ToString() + " views";
            uploaderLabel.Text = sr.uploader;
            thumbPictureBox.ImageLocation = sr.thumbUrl;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            parentQueue.removeSong(songRequest);
        }
    }
}
