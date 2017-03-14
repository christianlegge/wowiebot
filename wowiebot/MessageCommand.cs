using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wowiebot
{
    class MessageCommand : Command
    {
        private string command;
        private List<string> parameters;

        public MessageCommand(string command, params string[] parameters)
        {
            this.command = command;
            this.parameters = parameters.ToList();
        }

        public string getCommand()
        {
            return command;
        }

        public List<string> getParameters()
        {
            return parameters;
        }

        public void handle()
        {
            chatrig.sendMessage(parameters[0]);
        }
    }
}
