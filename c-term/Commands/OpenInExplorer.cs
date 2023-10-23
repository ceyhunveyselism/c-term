using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class OpenInExplorer: Command
    {
        public OpenInExplorer()
        {
            name = "explorer";
            description = "Not to be confused with Browse; This command opens the currentDirectory in the Windows Explorer.";
            usage = "explorer";
            aliases = new string[] { "openinexplorer", "explorer" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C explorer " + handler.currentDirectory;
            process.StartInfo = startInfo;
            process.Start();
            return new CommandReply(false, "Opened the currentDirectory in explorer.");
        }
    }
}
