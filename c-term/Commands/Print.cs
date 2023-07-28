using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class Print: Command
    {
        public Print()
        {
            name = "Print";
            description = "Prints/echoes back the argument. Requires arguments.";
            usage = "print [text]";
            aliases = new string[] { "print", "echo", "lb" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            if(arguments.Count < 1)
            {
                return new CommandReply(true, "Not enough arguments provided");
            } else
            {
                return new CommandReply(false, _QF.join(arguments, " ").Replace("\\n", "\n"));
            }
        }
    }
}
