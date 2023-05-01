using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class SlowPrint: Command 
    {
        /* This command is a little special.
         * Since normal commands have no actual way of pausing output as they give and receive data using console replies,
         * I have implemented a special string, "DNP", to tell the main program that the explanation of the CommandReply SHALL NOT be outputted.
         * This SlowPrint utilizes the actual Console (which you should never use! Always use the ConsoleReply, no matter what) */

        public SlowPrint()
        {
            name = "SlowPrint";
            description = "Prints [argument 2] over the duration of [argument 1].";
            aliases = new string[] { "sp", "slowecho", "why", "slowprint" }; // Little easter egg. I'm just asking why the fuck Delta even has a slowprint command in his terminal.
            usage = "slowprint [time (ms)] [text]";
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            try
            {
                int ms = Int32.Parse((string)arguments[0]) / arguments[1].Length;
                arguments.RemoveAt(0);
                string str = String.Join(" ", arguments.ToArray());
                for (int i = 0; i < str.Length; i++)
                {
                    Console.Write(str[i]);
                    Thread.Sleep(ms);
                }
                Console.WriteLine();
                return new CommandReply(false, "DNP");
            }
            catch
            {
                return new CommandReply(true, "Incorrect argument 1 [0x02]");
            }
            
        }
    }
}
