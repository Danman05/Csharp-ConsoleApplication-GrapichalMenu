using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Pastel;
using System.Drawing;

namespace GrapichalMenu.program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            View view = new View();
            Controller controller = new Controller();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            int selectedIndexOption = -1;
            bool terminate = false;
            string message = "";
            while (!terminate)
            {
                view.PrintMenu(selectedIndexOption, message);
                message = "";
                ConsoleKeyInfo cki;
                cki = Console.ReadKey();

                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        selectedIndexOption = 0;
                        view.PrintMenu(selectedIndexOption, message);
                        controller.PrintCodePage();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        selectedIndexOption = 1;
                        view.PrintMenu(selectedIndexOption, message);
                        Console.WriteLine();
                        Console.Write("Enter file name: ");
                        string? fileName = Console.ReadLine();
                        if (fileName != "")
                        {
                            controller.CreateTextFile(fileName);
                        }
                        else
                        {
                            message = "File not created, give the file a name".Pastel(Color.FromArgb(99, 0, 15));
                        }
                        break;
                    case ConsoleKey.D3:
                        selectedIndexOption = 2;
                        view.PrintMenu(selectedIndexOption, message);
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
    }
}