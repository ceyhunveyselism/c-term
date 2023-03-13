using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace c_term.Commands
{
    class ReadFile: Command
    {
        public ReadFile()
        {
            description = "Reads file at [argument 1].";
            usage = "readfile [path to file]";
            aliases = new string[] { "readfile", "rf", "read" };
        }

        public override CommandReply run(List<string> arguments)
        {
            if(arguments.Count < 1)
            {
                return new CommandReply(true, "Not enough arguments provided [0x01]");
            }

            if(!File.Exists(_QF.join(arguments, ""))) {
                return new CommandReply(true, "File not found [0x03]");
            } else
            {
                return new CommandReply(false, File.ReadAllText(_QF.join(arguments, "")));
            }
        }
    }
}
