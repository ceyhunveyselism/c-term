using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using c_term.Commands;

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
            Console.WriteLine("b14-v1.5.7 | Type help for commands\n");

            List<Command> commandList = new List<Command>();
            commandList.Add(new Ping());
            commandList.Add(new SetTitle());
            commandList.Add(new SlowPrint());
            commandList.Add(new ListDirectory());
            commandList.Add(new Print());
            commandList.Add(new Clear());
            commandList.Add(new WriteFile());
            commandList.Add(new CreateFile());
            commandList.Add(new ReadFile());
            CommandHandler ch = new CommandHandler(commandList);
            ch.CHCommandList.Add(new Help());

            while (true)
            {
                Console.Write("main-> ");
                string MAIN_ENTRY = Console.ReadLine();

                string command = MAIN_ENTRY.Split(' ')[0].ToLower();
                var arguments = new List<string>(MAIN_ENTRY.Split(' ').Skip(1).ToArray().ToList());

                CommandReply reply = ch.runCommand(command, arguments);
                if(reply.error && !(reply.explanation == "CNF") && !(reply.explanation == "DNP"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Command " + command + " encountered an error: " + reply.explanation);
                    Console.ResetColor();
                } else if(!reply.error && !(reply.explanation == "DNP"))
                {
                    Console.WriteLine(reply.explanation);
                } else if(reply.error && reply.explanation == "CNF")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Command not found/recognized. Check help if you are missing something.");
                    Console.ResetColor();
                }
            }
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
            string specific = File.ReadAllText(ctfile);
            string text = specific[specific.Length - specific.Length + 1].ToString();
            return text == "1" ? $"{specific}st" : text == "2" ? $"{specific}nd" : text == "3" ? $"{specific}rd" : specific + "th"; 
        }
    }
}







