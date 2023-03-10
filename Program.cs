using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Pastel;
using System.Drawing;

namespace GrapichalMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            int selectedIndexOption = -1;
            bool terminate = false;
            string message = "";
            while (!terminate)
            {
                PrintMenu(selectedIndexOption, message);
                message = "";
                ConsoleKeyInfo cki;
                cki = Console.ReadKey();

                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        selectedIndexOption = 0;
                        PrintMenu(selectedIndexOption, message);
                        PrintCodePage();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        selectedIndexOption = 1;
                        PrintMenu(selectedIndexOption, message);
                        Console.WriteLine();
                        Console.Write("Enter file name: ");
                        string? fileName = Console.ReadLine();
                        if (fileName != "")
                        {
                            CreateTextFile(fileName);
                        }
                        else
                        {
                            message = "File not created, give the file a name".Pastel(Color.FromArgb(99, 0, 15));
                        }
                        break;
                    case ConsoleKey.D3:
                        selectedIndexOption = 2;
                        PrintMenu(selectedIndexOption, message);
                        Process.Start("explorer.exe", @"H:\SKP\Programmering\Små opgaver\GrapichalMenu\bin\Debug\net6.0");

                        break;
                    case ConsoleKey.D4:
                        selectedIndexOption = 3;
                        break;
                    case ConsoleKey.D5:
                        selectedIndexOption = 4;
                        break;
                    case ConsoleKey.D6:
                        selectedIndexOption = 5;
                        break;
                    case ConsoleKey.D7:
                        selectedIndexOption = 6;
                        break;
                    case ConsoleKey.Q:
                        Console.Clear();
                        Console.Write("Goodbye!");
                        terminate = true;
                        break;
                    default:
                        message = "Invalid input".Pastel(Color.FromArgb(243, 228, 150));
                        break;
                }
            }
        }

        public static void PrintMenu(int selectedIndexOption, string message)
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
                if (i == selectedIndexOption)
                {
                    //Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{i + 1}. {listOptions[i]}".Pastel(Color.FromArgb(124, 252, 0)));
                }
                else
                {
                    Console.Write($"{i + 1}. {listOptions[i]}");
                }
                //Console.ResetColor();
                Console.Write(new String(' ', 46 - listOptions[i].Count()));
                Console.WriteLine($"{cp437.GetString(new byte[1] { 186 })}");
            }

            Console.Write($"{cp437.GetString(new byte[1] { 186 })}");
            Console.Write(new String(' ', 49));
            Console.WriteLine($"{cp437.GetString(new byte[1] { 186 })}");

            Console.Write($"{cp437.GetString(new byte[1] { 186 })}");
            Console.Write($"Choose between 1-7, press q to exit");
            Console.Write(new String(' ', 14));
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
        public static void PrintCodePage()
        {
            Console.WriteLine();
            StringBuilder sb = new StringBuilder();
            Encoding cp437 = Encoding.GetEncoding("IBM437");
            byte[] source = new byte[1];
            sb.Append(String.Format("{0,6} {1,15}\n\n", "Number", "Symbol"));

            for (byte i = 0x20; i < 0xFF; i++)
            {
                source[0] = i;
                sb.Append(String.Format("{0,6} {1,15}\n", i, cp437.GetString(source)));
            }
            Console.WriteLine(sb);
            Console.SetCursorPosition(0, 0);
        }

        public static void CreateTextFile(string name)
        {
            File.Create(name + ".txt");
        }
    }
}