using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace c_term.Commands
{
    class CreateFile: Command
    {
        public CreateFile()
        {
            name = "CreateFile";
            description = "Creates a file using the first argument.";
            usage = "createfile [file]";
            aliases = new string[] { "createfile", "makefile","mf","cf","touch"};
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            if(arguments.Count < 1)
            {
                return new CommandReply(true, "Not enough arguments provided");
            }

            if (File.Exists(handler.currentDirectory + "\\" + string.Join(" ", arguments)))
            {
                return new CommandReply(true, "File already exists");
            }

            try
            {
                File.Create(handler.currentDirectory + "\\" + _QF.join(arguments, "")).Close();
                return new CommandReply(false, "Successfully created file");
            }
            catch
            {
                return new CommandReply(true, "Something went wrong.");
            }
        }
    }
}
