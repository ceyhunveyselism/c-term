using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class WriteFile: Command
    {
        public WriteFile()
        {
            name = "WriteFile";
            description = "Writes or overwrites data onto an already existant file.";
            usage = "writefile <path> <data> [overwrite? 0/1]";
            aliases = new string[] { "wf", "write" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            if(arguments.Count < 2)
            {
                return new CommandReply(true, "Not enough arguments provided [0x01]");
            }

            int overwrite;

            try
            {
                if(arguments.Count >= 3)
                {
                    overwrite = Int32.Parse(arguments[2]);
                }
            } catch
            {
                return new CommandReply(true, "Incorrect argument 3 [0x02]");
            }

            if (!File.Exists(arguments[0]))
            {
                return new CommandReply(true, "File not found [0x03]");
            }

            if (arguments.Count >= 3 && Int32.Parse(arguments[2]) == 1)
            {
                File.WriteAllText(arguments[0], arguments[1]);
            } else
            {
                File.WriteAllText(handler.currentDirectory + "\\" + arguments[0], File.ReadAllText(handler.currentDirectory + "\\" + arguments[0]) + arguments[1]);
            }

            return new CommandReply(false, "Successfully written data onto file");
        }
    }
}
