using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term
{
    class CHCommand
    {
        public string description = "N/A";
        public string[] aliases;
        public string usage = "N/A";

        public virtual CommandReply run(CommandHandler handler, ArrayList arguments)
        {
            return new CommandReply(false, "N/A");
        }
    }
}
