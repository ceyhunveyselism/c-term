using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class DeleteDirectory: Command
    {
        public DeleteDirectory()
        {
            name = "DeleteDirectory";
            description = "Deletes a directory. Use browse to navigate through directories.";
            usage = "deletedir <recursive? 0 or 1> <directory path>";
            aliases = new string[] { "deletedir", "deletedirectory", "deldir", "rd" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            try
            {
                bool recursive = bool.Parse(arguments[0]);
                if (arguments.Count < 2)
                {
                    return new CommandReply(true, "Not enough arguments provided");
                }

                string directoryName = string.Join(" ", arguments);

                if (!Directory.Exists(directoryName))
                {
                    return new CommandReply(true, "That directory doesn't exist");
                }

                Directory.Delete(directoryName, recursive);
                return new CommandReply(false, $"Directory successfully removed.");
            } catch
            {
                return new CommandReply(true, "Something went wrong. Maybe you named the directory incorrectly?");
            }
        }
    }
}
