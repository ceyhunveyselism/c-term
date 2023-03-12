using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections;

namespace c_term
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            usesUpdate();
            Console.WriteLine($"Hello, {userName.Split('\\')[1]}! This is your {getUses()} time using c-term.");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("b4-v0.1.2 | Type help for commands\n");

            while(true)
            {
                Console.Write("main-> ");
                string MAIN_ENTRY = Console.ReadLine();

                string command = MAIN_ENTRY.Split(' ')[0];
                var arguments = new ArrayList(MAIN_ENTRY.Split(' ').Skip(1).ToArray().ToList());

                if(command == "ping")
                {
                    if(arguments.Count == 0)
                    {
                        Console.WriteLine("Pong!");
                    } else
                    {
                        Console.WriteLine("Pong! Excessive arguments: " + join(arguments, ","));
                    }
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed to recognize command.");
                    Console.ResetColor();
                }

            }
        }

        static string join(ArrayList al, string delimiter)
        {
            string str = "";
            for(int i = 0; i < al.Count; i++)
            {
                str += al[i] + (i != al.Count - 1 ? $"{delimiter} " : " ");
            }
            return str;
        }

        static string usesUpdate()
        {
            string ctfile = Path.GetTempPath() + "cterm.ct";
            if(File.Exists(ctfile))
            {
                File.WriteAllText(ctfile, (Int32.Parse(File.ReadAllText(ctfile)) + 1).ToString());
                return File.ReadAllText(ctfile);
            } else
            {
                File.Create(ctfile).Close();
                File.WriteAllText(ctfile, "1");
                return "1";
            }
        }

        static string getUses()
        {
            string ctfile = Path.GetTempPath() + "cterm.ct";
            string text = File.ReadAllText(ctfile);
            return text == "1" ? "1st" : text == "2" ? "2nd" : text == "3" ? "3rd" : text + "th"; 
        }
    }
}
