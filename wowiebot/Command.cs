using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    interface Command
    {
        string getCommand();
        List<string> getParameters();
        void handle();

    }
}
