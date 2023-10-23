using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class Evaluate: Command
    {
        public Evaluate()
        {
            name = "Evaluate";
            description = "Evaluates whatever you give it.";
            usage = "eval 1 + 5";
            aliases = new string[] { "eval", "evaluate", "calculate", "math" };
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            try
            {
                if (arguments.Count == 0)
                {
                    return new CommandReply(true, "Not enough arguments provided");
                }
                return new CommandReply(false, Evaluate2(String.Join(" ", arguments.ToArray<string>())).ToString());
            } catch (SyntaxErrorException)
            {
                return new CommandReply(true, "I don't think that's how math works chief");
            } catch (OverflowException)
            {
                return new CommandReply(true, "Integer overload! Those numbers are too big.");
            } catch (EvaluateException)
            {
                return new CommandReply(true, "Incorrect arguments");
            }
        }

        public static double Evaluate2(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
    }
}
