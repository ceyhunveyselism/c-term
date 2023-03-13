using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term
{
    class CommandReply
    {
        public bool error;
        public string explanation;

        public CommandReply(bool error, string explanation)
        {
            this.explanation = explanation;
            this.error = error;
        }
    }
}
