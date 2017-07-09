using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ReverseNumber
{
    class ReverseNumber
    {
        static void Main()
        {
            string num = Console.ReadLine();
            string NewNum = "";
            for (int i = num.Length - 1; i > -1; i--)
            {
                NewNum += num[i];
            }
            Console.WriteLine(NewNum);
        }
    }
}
