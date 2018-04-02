using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    public class SongRequestQueue
    {
        private Queue<SongRequest> queue;

        public SongRequestQueue()
        {
            queue = new Queue<SongRequest>();
        }

        public void queueSong(SongRequest sr)
        {
            queue.Enqueue(sr);
        }
    }
}
