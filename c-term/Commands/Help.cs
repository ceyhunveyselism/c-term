using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class Help: Command
    {
        public Help()
        {
            name = "Help";
            description = "The help command. Shows how to use all commands, what aliases they have, and the description of them.";
            aliases = new string[] { "help", "cmds", "commands" };
            usage = "help [command]";
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            if(arguments.Count > 0)
            {
                for(int i = 0; i < handler.CommandList.Count; i++)
                {
                    if (handler.CommandList[i].aliases.Contains(arguments[0]))
                    {
                        Command currentCommand = handler.CommandList[i];
                        return new CommandReply(false, "Aliases: [" + String.Join(", ", currentCommand.aliases) + "] | Description: " + currentCommand.description + " | Usage: " + currentCommand.usage + "\n");
                    }
                }
                return new CommandReply(true, "Command not found");
            }

            string helpString = "";

            for(int i = 0; i < handler.CommandList.Count; i++)
            {
                Command currentCommand = handler.CommandList[i];
                helpString += "Command #" + (i+1) + ": " + "Name: " + currentCommand.name + " | " + "Aliases: [" + String.Join(", ", currentCommand.aliases) + "] | Description: " + currentCommand.description + " | Usage: " + currentCommand.usage + "\n";
            }

            return new CommandReply(false, helpString);
        }
    }
}
