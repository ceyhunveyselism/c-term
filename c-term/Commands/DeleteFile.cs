using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class DeleteFile: Command
    {
        public DeleteFile()
        {
            name = "DeleteFile";
            usage = "rf <path>";
            aliases = new string[] { "rf", "removefile", "deletefile", "df", "delete", "del", "rm", "remove", "rem", "remfile", "delfile" };
            description = "Delete a file.";
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            if (arguments.Count < 1) return new CommandReply(true, "Not enough arguments provided");
            if(!File.Exists(handler.currentDirectory + "\\" + string.Join(" ", arguments)))
            {
                return new CommandReply(true, "That file doesn't exist");
            } else
            {
                File.Delete(handler.currentDirectory + "\\" + string.Join(" ", arguments));
                return new CommandReply(false, "File deleted successfully");
            }
        }
    }
}
