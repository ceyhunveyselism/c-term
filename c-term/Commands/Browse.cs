using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_term.Commands
{
    class Browse: Command
    {
        public Browse()
        {
            name = "Browse";
            description = "Browse folders like explorer. Uses your currentDirectory.";
            aliases = new string[] { "fs", "tv", "browse" };
            usage = "fs";
        }

        public override CommandReply run(CommandHandler handler, List<string> arguments)
        {
            try {
                bool finish = false;
                Console.CursorVisible = false;
                while (true)
                {
                    if (!handler.currentDirectory.EndsWith("\\")) { handler.currentDirectory = handler.currentDirectory + "\\"; }
                    if (finish) { Console.CursorVisible = true; return new CommandReply(false, "DNP"); };
                    List<string> folders = new List<string>{
                    "../"
                };
                    foreach (string folder in Directory.GetDirectories(handler.currentDirectory))
                    {
                        folders.Add(folder.Split('\\').Last());
                    }
                    int sel = 0;
                    while (true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Current Folder: " + handler.currentDirectory);
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (string folder in folders)
                        {
                            if (folders[sel] == folder)
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(folder);
                            Console.ResetColor();
                        }
                        ConsoleKey key = Console.ReadKey().Key;
                        if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                        {
                            sel = (sel == folders.Count - 1) ? 0 : sel + 1;
                        }
                        else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                        {
                            sel = (sel == 0) ? folders.Count - 1 : sel - 1;
                        }
                        else if (key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            break;
                        }
                        else if (key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            Console.CursorVisible = true;
                            finish = true;
                            sel = -1;
                            break;
                        }
                    }
                    if (sel == -1)
                    {
                        return new CommandReply(false, "DNP");
                    }
                    string selectedItem = folders[sel];
                    if (selectedItem == "../")
                    {
                        handler.currentDirectory = string.Join("\\", handler.currentDirectory.Split('\\').Reverse().Skip(2).Reverse().ToArray());
                    } else
                    {
                        if (!handler.currentDirectory.EndsWith("\\"))
                        {
                            handler.currentDirectory = handler.currentDirectory + "\\" + selectedItem;
                        } else
                        {
                            handler.currentDirectory = handler.currentDirectory + selectedItem;
                        }
                    }
                }
            } catch(Exception e)
            {
                handler.currentDirectory = handler.firstDirectory;
                return new CommandReply(true, e.Message + "\nBrowse will now revert to the original folder as to avoid any errors.");
            }
        }
    }
}
