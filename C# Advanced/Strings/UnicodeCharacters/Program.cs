using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            foreach (char sym in line)
            {
                sb.Append(String.Format("\\u{0:X4}", (ushort)sym));
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
