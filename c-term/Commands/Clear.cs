using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class Clear: Command
    {
        public Clear()
        {
            description = "Clears the console.";
            aliases = new string[] { "clr", "cls", "clear" };
            usage = "clear";
        }

        public override CommandReply run(List<string> arguments)
        {
            Console.Clear();
            return new CommandReply(false, "Cleared the console.");
        }
    }
}
