using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class Length: Command
    {
        public Length()
        {
            name = "Length";
            description = "Get the length of text.";
            usage = "len <text>";
            aliases = new string[] { "len", "length", "getlen", "strlen", "strlength", "getlength", "lenget"};
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            if(arguments.Count == 0)
            {
                return new CommandReply(true, "Not enough arguments");
            }

            return new CommandReply(false, string.Join(" ", arguments.ToArray()).Length.ToString());
        }
    }
}
