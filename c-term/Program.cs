using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using c_term.Commands;

// Fun Fact: Making modifications to this file is a headache. Please don't.

namespace c_term
{
    
    internal class Program
    {
        static bool canaryRelease = true;
        static void Main(string[] args)
        {
            Console.Title = "C-Term v2.0.0";
            Console.Clear();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            usesUpdate();
            Console.WriteLine($"Hello, {userName.Split('\\')[1]}! This is your {getUses()} time using c-term. {(userName.Split('\\')[1] == "Ceyhun" ? "How's the development going?" : "")}{(userName.Split('\\')[1] == "Deltact" ? "How's EnDe development going?" : "")}");
            Console.WriteLine("--------------------------------------------------");
            if (canaryRelease)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!! Canary Release !!");
                Console.ResetColor();
            }
            Console.WriteLine("b32-v2.6.2 | Type help for commands\n");
            

            List<Command> commandList = new List<Command>
            {
                new Ping(),
                new SetTitle(),
                new SlowPrint(),
                new Print(),
                new Clear(),
                new Help(),
                new CreateFile(),
                new ListDirectory(),
                new WriteFile(),
                new ReadFile(),
                new Settings(),
                new Browse(),
                new DeleteFile(),
                new Evaluate(),
                new RNG(),
                new OpenInExplorer(),
                new CommandLine(),
                new DeleteDirectory(),
                new CreateDirectory(),
                new Length()
            };
            CommandHandler ch = new CommandHandler(commandList);
            bool awesome = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                string display;
                if(ch.showCurrentDirectoryFull) { display = ch.currentDirectory;  } else if(ch.showCurrentDirectory) { string[] arr = ch.currentDirectory.Split('\\'); display = arr[arr.Count() - 2]; } else { display = "";  };
                Console.Write(display + ch.cdStartingPrefix + " ");
                string MAIN_ENTRY = Console.ReadLine().Trim();

                string command = MAIN_ENTRY.Split(' ')[0].ToLower();
                var arguments = new List<string>(MAIN_ENTRY.Split(' ').Skip(1).ToArray().ToList());

                if (command.Trim() == "") continue;

                // shhhhhhh..
                if(command == "awesome")
                {
                    awesome = !awesome;
                    Console.ForegroundColor = (awesome == true) ? ConsoleColor.DarkGreen : ConsoleColor.White;
                    Console.WriteLine((awesome == true) ? "awesome indeed :)" : "no longer awesome :(");
                    continue;
                }

                CommandReply reply = ch.runCommand(command, arguments);
                if(reply.error && !(reply.explanation == "CNF") && !(reply.explanation == "DNP"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Command " + command + " encountered an error: " + reply.explanation);
                    if (!awesome) Console.ForegroundColor = ConsoleColor.White; else Console.ForegroundColor = ConsoleColor.DarkGreen;
                } else if(!reply.error && !(reply.explanation == "DNP"))
                {
                    Console.WriteLine(reply.explanation);
                } else if(reply.error && reply.explanation == "CNF")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Command not found/recognized. Check help if you are missing something.");
                    if (!awesome) Console.ForegroundColor = ConsoleColor.White; else Console.ForegroundColor = ConsoleColor.DarkGreen;
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
            string text = specific[specific.Length - 1].ToString();
            return text == "1" ? $"{specific}st" : text == "2" ? $"{specific}nd" : text == "3" ? $"{specific}rd" : specific + "th"; 
        }
    }
}