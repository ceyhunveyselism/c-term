using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term
{
    class CommandHandler
    {
        public string currentDirectory = Directory.GetCurrentDirectory();

        public List<Command> CommandList = new List<Command>();
        public List<CHCommand> CHCommandList = new List<CHCommand>();
        public CommandHandler(List<Command> CommandList)
        {
            this.CommandList = CommandList;
        }

        public CommandReply runCommand(string commandName, List<string> arguments)
        {
            for (int i = 0; i < CommandList.Count; i++)
            {
                Command currentCommand = CommandList[i];
                for (int a = 0; a < currentCommand.aliases.Length; a++)
                {
                    if (commandName == currentCommand.aliases[a])
                    {
                        return currentCommand.run(arguments);
                    }
                }
            }
            return runCHCommand(commandName, arguments);
        }

        public CommandReply runCHCommand(string commandName, List<string> arguments)
        {
            for (int i = 0; i < CHCommandList.Count; i++)
            {
                CHCommand currentCommand = CHCommandList[i];
                for (int a = 0; a < currentCommand.aliases.Length; a++)
                {
                    if (commandName == currentCommand.aliases[a])
                    {
                        return currentCommand.run(this, arguments);
                    }
                }
            }
            return new CommandReply(true, "CNF");
        }

        public bool commandExists(string commandName)
        {
            for (int i = 0; i < CommandList.Count; i++)
            {
                Command currentCommand = CommandList[i];
                for (int a = 0; i < currentCommand.aliases.Length; a++)
                {
                    if (commandName == currentCommand.aliases[a])
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < CHCommandList.Count; i++)
            {
                CHCommand currentCommand = CHCommandList[i];
                for (int a = 0; i < currentCommand.aliases.Length; a++)
                {
                    if (commandName == currentCommand.aliases[a])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        
    }
}
