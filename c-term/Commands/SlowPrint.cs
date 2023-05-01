using System;
using System.Collections.Generic;
using System.Threading;

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
                int arg0 = int.Parse(arguments[0]);
                arguments.RemoveAt(0);
                string str = String.Join(" ", arguments.ToArray());
                int ms = arg0 / str.Length;
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
