using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLength
{
    class StringLength
    {
        static void Main()
        {
            string line = Console.ReadLine();

            if (line.Length > 20)
            {
                Console.WriteLine(line.Substring(0,19));
            }
            else
            {
                Console.WriteLine(line.PadRight(20, '*'));
            }
        }
    }
}
