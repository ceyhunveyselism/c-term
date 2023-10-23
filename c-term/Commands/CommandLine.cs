using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class CommandLine: Command
    {
        public CommandLine()
        {
            name = "CommandLine";
            description = "Opens the command line in the currentDirectory.";
            usage = "cmd";
            aliases = new string[] { "cmd", "commandline", "terminal" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            var proc1 = new ProcessStartInfo();
            proc1.UseShellExecute = false;
            proc1.WorkingDirectory = handler.currentDirectory;

            proc1.FileName = @"cmd";
            proc1.Verb = "runas";
            proc1.WindowStyle = ProcessWindowStyle.Normal;
            Console.Title = "cmd";
            Process.Start(proc1);
            return new CommandReply(false, "Opened the command line.");
        }
    }
}
