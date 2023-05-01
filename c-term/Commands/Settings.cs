using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class Settings : Command
    {
        public Settings()
        {
            name = "Settings";
            usage = "settings <setting> <value>";
            description = "Allows you to change the settings of c-term. Using it with no arguments will show the current values of all settings and their names.";
            aliases = new string[] { "settings", "options", "set" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            if(arguments.Count == 2)
            {
                object option;
                if (!(arguments[0] != "cdStartingPrefix" && arguments[0] != "showCurrentDirectory" && arguments[0] != "showCurrentDirectoryFull"))
                {
                    
                    if (arguments[1] == "true" || arguments[1] == "false")
                    {
                        option = bool.Parse(arguments[1]);
                    } else
                    {
                        option = arguments[1];
                    }

                    if(option is bool)
                    {
                        if (arguments[0] == "showCurrentDirectory")
                        {
                            handler.showCurrentDirectory = (bool)option;
                        }

                        if (arguments[0] == "showCurrentDirectoryFull")
                        {
                            handler.showCurrentDirectoryFull = (bool)option;
                        }
                    } else
                    {
                        handler.cdStartingPrefix = arguments[1];
                    }
                    return new CommandReply(false, arguments[0] + " -> " + arguments[1]);
                }
                return new CommandReply(true, "Setting not found");
            } else
            {
                return new CommandReply(false, $"cdStartingPrefix | The prefix after the current directory. Default: -> | Value: {handler.cdStartingPrefix}\nshowCurrentDirectoryFull | True if you want to show the full current directory before the prefix. False if only the end of the folder is shown. Default: true | Value: {handler.showCurrentDirectoryFull}\nshowCurrentDirectory | True if you want to show the current directory before the prefix. False if nothing is shown before the prefix. Default: false | Value: {handler.showCurrentDirectory}");
            }
        }
    }
}
