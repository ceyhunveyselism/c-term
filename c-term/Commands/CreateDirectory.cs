using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class CreateDirectory: Command
    {
        public CreateDirectory()
        {
            name = "CreateDirectory";
            description = "Creates a directory. Use browse to navigate through directories.";
            usage = "createdir <directory name>";
            aliases = new string[] { "mkdir", "makedir", "makedirectory", "createdir", "createdirectory", "md" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            try
            {
                if (arguments.Count < 0)
                {
                    return new CommandReply(true, "Not enough arguments provided");
                }

                string directoryName = string.Join(" ", arguments);

                if (Directory.Exists(directoryName))
                {
                    return new CommandReply(true, "That directory already exists");
                }

                Directory.CreateDirectory(handler.currentDirectory + directoryName);
                return new CommandReply(false, "Directory successfully created");
            } catch
            {
                return new CommandReply(true, "Something went wrong. Maybe you named the directory incorrectly?");
            }
        }
    }
}
