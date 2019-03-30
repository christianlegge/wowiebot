using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace wowiebot
{
    public class Command
    {
        public string message;
        public List<string> allowedUsers;

        public Command(string msg, List<string> allowed)
        {
            this.message = msg;
            Regex r = new Regex("^[A-Za-z0-9_]+$");
            allowedUsers = new List<string>();
            foreach (string a in allowed)
            {
                if (a.Trim().ToLower() == "$mod" || r.IsMatch(a.Trim()) )
                {
                    allowedUsers.Add(a.Trim().ToLower());
                }
            }
        }
    }
}
