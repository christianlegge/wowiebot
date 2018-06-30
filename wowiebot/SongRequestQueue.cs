using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    public class SongRequestQueue
    {
        private List<SongRequest> q = new List<SongRequest>();
        public event EventHandler QueueChanged;

        public SongRequestQueue()
        {

        }

        public void queueSong(SongRequest sr)
        {
            q.Add(sr);
            QueueChanged(this, null);
        }

        public SongRequest songFinished()
        {
            if (q.Count == 0)
            {
                throw new Exception("No song was playing");
            }
            q.RemoveAt(0);
            QueueChanged(this, null);
            if (q.Count == 0)
            {
                return null;
            }
            return q.First();
        }

        public void removeSong(SongRequest sr)
        {
            List<SongRequest> l = new List<SongRequest> { sr };
            if (q.Contains(sr))
            {
                q.Remove(sr);
                QueueChanged(this, null);
            }
        }

        public IEnumerator<SongRequest> GetEnumerator()
        {
            return q.GetEnumerator();
        }
    }
}
