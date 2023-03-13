using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class Help: CHCommand
    {
        public Help()
        {
            description = "The help command. Shows how to use all commands, what aliases they have, and the description of them.";
            aliases = new string[] { "help", "cmds", "commands" };
            usage = "help [command]";
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            string helpString = "--- NORMAL COMMANDS ---\n";

            for(int i = 0; i < handler.CommandList.Count; i++)
            {
                Command currentCommand = handler.CommandList[i];
                helpString += "Aliases: [" + String.Join(", ", currentCommand.aliases) + "] | Description: " + currentCommand.description + " | Usage: " + currentCommand.usage + "\n";
            }

            helpString += "--- CH COMMANDS ---\n";

            for (int i = 0; i < handler.CHCommandList.Count; i++)
            {
                CHCommand currentCommand = handler.CHCommandList[i];
                helpString += "Aliases: [" + String.Join(", ", currentCommand.aliases) + "] | Description: " + currentCommand.description + " | Usage: " + currentCommand.usage + "\n";
            }

            return new CommandReply(false, helpString);
        }
    }
}
