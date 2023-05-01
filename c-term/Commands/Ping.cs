using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class Ping : Command
    {
        public Ping()
        {
            name = "Ping";
            aliases = new string[] { "ping", "pt" };
            description = "The ping function pings back with additional arguments.";
            usage = "ping [arguments]";
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            return new CommandReply(false, arguments.Count >= 1 ? "Ping! Additional arguments: " + _QF.join(arguments, ", ") : "Ping!");
        }
    }
}
