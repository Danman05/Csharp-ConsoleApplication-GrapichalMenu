using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Pastel;
using System.Drawing;
using System.Collections.Immutable;

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
                        view.PrintMenu(selectedIndexOption, message);
                        Console.Write("\nEnter number: ");
                        int numbers = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"\nOrder by descending number returned: {OrderDescenNum(numbers)}");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D5:
                        selectedIndexOption = 4;
                        view.PrintMenu(selectedIndexOption, message);
                        Console.Write("\nEnter number: ");
                        int squareNum = Int32.Parse(Console.ReadLine());
                        bool squareResult = PerfectSquare(squareNum);
                        if (squareResult)
                        {
                            Console.WriteLine($"\nPerfect square returned: {squareResult.ToString().Pastel(Color.FromArgb(0, 230, 0))}");
                        }
                        else
                        {
                            Console.WriteLine($"\nPerfect square returned: {squareResult.ToString().Pastel(Color.FromArgb(230, 0, 0))}");
                        }

                        Console.ReadKey();
                        break;
                    case ConsoleKey.D6:
                        selectedIndexOption = 5;
                        view.PrintMenu(selectedIndexOption, message);
                        break;
                    case ConsoleKey.D7:
                        selectedIndexOption = 6;
                        view.PrintMenu(selectedIndexOption, message);
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

        private static int OrderDescenNum(int num)
        {
            string result = "";
            string numStr = num.ToString();
            int[] numArr = new int[numStr.Length];

            for (int i = 0; i < numStr.Length; i++)
            {
                numArr[i] = Int32.Parse(numStr[i].ToString());
            }

            Array.Sort(numArr);
            Array.Reverse(numArr);

            for (int i = 0; i < numArr.Length; i++)
            {
                result += numArr[i].ToString();
            }
            return Int32.Parse(result);
        }
        private static bool PerfectSquare(int squareNum)
        {
            double result = Math.Sqrt(squareNum);
            return result % 1 == 0;
        }
    }
}