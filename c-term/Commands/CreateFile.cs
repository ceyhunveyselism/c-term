using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace c_term.Commands
{
    class CreateFile: CHCommand
    {
        public CreateFile()
        {
            description = "Creates a file using the first argument.";
            usage = "createfile [file]";
            aliases = new string[] { "createfile", "makefile","mf","cf" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            if(arguments.Count < 1)
            {
                return new CommandReply(true, "Not enough arguments provided [0x01]");
            }

            if(File.Exists(_QF.join(arguments, "")))
            {
                return new CommandReply(true, "File already exists [0x04]");
            }

            try
            {
                File.Create(handler.currentDirectory + "\\" + _QF.join(arguments, "")).Close();
                return new CommandReply(false, "Successfully created file");
            }
            catch
            {
                return new CommandReply(true, "Something went wrong [FATAL ERROR]");
            }
        }
    }
}
