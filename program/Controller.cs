using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapichalMenu.program
{
    internal class Controller
    {
        public void PrintCodePage()
        {
            Console.WriteLine();
            StringBuilder sb = new StringBuilder();
            Encoding cp437 = Encoding.GetEncoding("IBM437");
            byte[] source = new byte[1];
            sb.Append(string.Format("{0,6} {1,15}\n\n", "Number", "Symbol"));

            for (byte i = 0x20; i < 0xFF; i++)
            {
                source[0] = i;
                sb.Append(string.Format("{0,6} {1,15}\n", i, cp437.GetString(source)));
            }
            Console.WriteLine(sb);
            Console.SetCursorPosition(0, 0);
        }
        public void CreateTextFile(string name)
        {
            string fileName = name + ".txt";
            File.Create(fileName).Close();

        }
    }
}
