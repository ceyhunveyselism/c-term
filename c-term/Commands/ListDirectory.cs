using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class ListDirectory: Command
    {
        public ListDirectory()
        {
            name = "ListDirectory";
            description = "Lists every file in the current directory.";
            usage = "listdir [don't use full path?]";
            aliases = new string[] { "listdir", "listdirectory", "dir", "ls" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            string pathing = _QF.join(Directory.GetFiles(handler.currentDirectory).ToList(), "\n");
            if(arguments.Count > 0)
            {
                List<string> newPathing = new List<string>();
                List<string> newerPathing = new List<string>();
                newPathing = Directory.GetFiles(Directory.GetCurrentDirectory()).ToList();

                for(int i = 0; i < newPathing.Count; i++)
                {
                    List<string> newernewerPathing = new List<string>(newPathing[i].Split('\\').ToList()); // GOD IM FUCKING DONE WITH MAKING LISTS FOR FUCKS SAKE THIS IS THE 3RD FUCKING TIME
                    newerPathing.Add(newernewerPathing[newernewerPathing.Count - 1]);
                }
                if (newerPathing[0] == "" && newerPathing.Count == 1)
                {
                    return new CommandReply(false, "No files in folder");
                }
                return new CommandReply(false, _QF.join(newerPathing, "\n"));
            }

            return new CommandReply(false, pathing);
        }
    }
}
