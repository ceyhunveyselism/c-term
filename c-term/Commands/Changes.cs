using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class Changes: Command
    {
        public Changes()
        {
            name = "Changes";
            description = "View the latest changes in the new version!";
            usage = "changelogs";
            aliases = new string[] { "changelogs", "changes", "news", "whatsnew" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            return new CommandReply(false, "Changes in v2.0.0: The browse command has been implemented. Use help browse for more details");
        }
    }
}
