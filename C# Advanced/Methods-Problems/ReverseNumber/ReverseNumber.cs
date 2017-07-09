using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumber
{
    class ReverseNumber
    {
        static void Reversing(string line)
        {
            string num = "";
            for (int i = line.Length-1; i > -1; i--)
            {
                num += line[i];
            }
            Console.WriteLine(num);
        }
        static void Main()
        {
            string l = Console.ReadLine();
            Reversing(l);
        }
    }
}
