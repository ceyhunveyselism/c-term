using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term
{
    class Command
    {
        public string description = "N/A";
        public string[] aliases;
        public string usage = "N/A";
        public string name = "N/A";

        public virtual CommandReply run(CommandHandler handler, List<string> arguments)
        {
            return new CommandReply(false, arguments.Count >= 1 ? "N/A" : "N/A - Arguments: " + _QF.join(arguments, ","));
        }

        //public Func<ArrayList, CommandReply> run { get; set; }
    }
}
