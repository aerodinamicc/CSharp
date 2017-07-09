using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Reverse
    {
        static void Main()
        {
            string line = Console.ReadLine();
            string result = "";
            for (int i = line.Length - 1; i > -1; i--)
            {
                result += line[i];
            }
            Console.WriteLine(result);
        }
    }
}
