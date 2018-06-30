using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    public class SongRequestQueue
    {
        private Queue<SongRequest> q = new Queue<SongRequest>();
        public event EventHandler QueueChanged;

        public SongRequestQueue()
        {

        }

        public void queueSong(SongRequest sr)
        {
            q.Enqueue(sr);
            QueueChanged(this, null);
        }

        public SongRequest songFinished()
        {
            if (q.Count == 0)
            {
                throw new Exception("No song was playing");
            }
            q.Dequeue();
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
                q.Except(new List<SongRequest> { sr });
            }
        }

        public IEnumerator<SongRequest> GetEnumerator()
        {
            return q.GetEnumerator();
        }
    }
}
