using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapichalMenu.program
{
    internal class View
    {
        public void PrintMenu(int currentIndex, string message)
        {
            Encoding cp437 = Encoding.GetEncoding("IBM437");
            string[] listOptions = {
                "See Character List",
                "Create Text File",
                "Open Workspace Directory",
                "Something different",
                "Something strange",
                "Something weird",
                "Something wrong"
            };
            Console.Clear();

            Console.Write($"{cp437.GetString(new byte[1] { 213 })}");
            for (int i = 1; i < 50; i++)
            {
                Console.Write($"{cp437.GetString(new byte[1] { 205 })}");
            }
            Console.WriteLine($"{cp437.GetString(new byte[1] { 183 })}");

            for (int i = 0; i < listOptions.Length; i++)
            {
                Console.Write($"{cp437.GetString(new byte[1] { 186 })}");
                if (i == currentIndex)
                {
                    //Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{i + 1}. {listOptions[i]}".Pastel(Color.FromArgb(124, 252, 0)));
                }
                else
                {
                    Console.Write($"{i + 1}. {listOptions[i]}");
                }
                //Console.ResetColor();
                Console.Write(new string(' ', 46 - listOptions[i].Count()));
                Console.WriteLine($"{cp437.GetString(new byte[1] { 186 })}");
            }

            Console.Write($"{cp437.GetString(new byte[1] { 186 })}");
            Console.Write(new string(' ', 49));
            Console.WriteLine($"{cp437.GetString(new byte[1] { 186 })}");

            Console.Write($"{cp437.GetString(new byte[1] { 186 })}");
            Console.Write($"Choose between 1-7, press q to exit");
            Console.Write(new string(' ', 14));
            Console.WriteLine($"{cp437.GetString(new byte[1] { 186 })}");

            Console.Write($"{cp437.GetString(new byte[1] { 212 })}");
            for (int i = 1; i < 50; i++)
            {
                Console.Write($"{cp437.GetString(new byte[1] { 205 })}");
            }
            Console.Write($"{cp437.GetString(new byte[1] { 190 })}\n");

            if (message != "")
            {
                Console.Write($"Alert! Message: ".Pastel(Color.FromArgb(122, 0, 18)) + $"{message}");
            }
            Console.Write($"\nEnter choice: ");
        }
    }
}
