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
        SongRequest sr;

        public SongRequestControl(SongRequest sr)
        {
            InitializeComponent();

            titleLabel.Text = sr.title;
            durationLabel.Text = sr.duration.ToString();
            viewsLabel.Text = sr.duration.ToString() + " views";
            uploaderLabel.Text = sr.uploader;
            thumbPictureBox.ImageLocation = sr.thumbUrl;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
