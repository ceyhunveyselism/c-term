using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class RNG: Command
    {
        public RNG()
        {
            name = "Random";
            description = "Generates a random number.";
            usage = "rng <min> <max> [amount?] [if save to file, filename?]";
            aliases = new string[] { "rng", "random", "rand" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            try
            {
                List<int> randomNumbers = new List<int>();
                int amount = 1;
                if (arguments.Count < 2)
                {
                    return new CommandReply(true, "Not enough arguments provided");
                }
                Random random = new Random();
                if (arguments.Count >= 3)
                {
                    amount = int.Parse(arguments[2]);
                }
                for (int i = 0; i < amount; i++)
                {
                    randomNumbers.Add(random.Next(int.Parse(arguments[0]), int.Parse(arguments[1])));
                }
                if (arguments.Count >= 4)
                {
                    arguments.RemoveRange(0, 3);
                    string filename = string.Join(" ", arguments.ToArray());
                    File.WriteAllText(handler.currentDirectory + filename, string.Join("\n", randomNumbers.ToArray()));
                }
                return new CommandReply(false, string.Join(", ", randomNumbers.ToArray()));
            } catch(ArgumentOutOfRangeException e)
            {
                return new CommandReply(true, "One of the arguments were wrong.");
            } catch(FormatException)
            {
                return new CommandReply(true, "One of the arguments were wrong.");
            } catch(OverflowException)
            {
                return new CommandReply(true, "Integer overflow! Those numbers are too big.");
            }
        }
    }
}
