using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class SetTitle: Command
    {
        public SetTitle()
        {
            description = "Sets the title of the console window.";
            usage = "settitle <title>";
            aliases = new string[] { "title", "settitle", "windowtitle", "swt"};
        }
        public override CommandReply run(List<string> arguments)
        {
            if(arguments.Count < 1)
            {
                return new CommandReply(true, "Not enough arguments provided [0x01]");
            } else
            {
                Console.Title = _QF.join(arguments, " ");
                return new CommandReply(false, "Successfully changed window title");
            }
        }
    }
}
