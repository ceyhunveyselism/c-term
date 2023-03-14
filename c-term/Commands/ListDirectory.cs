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
            description = "Lists every file in the current directory.";
            usage = "listdir";
            aliases = new string[] { "listdir", "listdirectory", "dir" };
        }

        public override CommandReply run(List<string> arguments)
        {
            return new CommandReply(false, _QF.join(Directory.GetFiles(Directory.GetCurrentDirectory()).ToList<string>(), "\n"));
        }
    }
}
