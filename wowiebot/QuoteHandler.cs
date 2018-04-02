using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    class QuoteHandler
    {
        static QuoteHandler instance = new QuoteHandler();
        public static QuoteHandler getInstance()
        {
            return instance;
        }
    }
}
