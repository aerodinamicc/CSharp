using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeNumbers
{
    class ThreeNumbers
    {
        static void Main()
        {
            double digit = double.Parse(Console.ReadLine());
            double max = digit;
            double min = digit;
            double sum = digit;

            for (int i = 0; i < 2; i++)
            {
                digit = double.Parse(Console.ReadLine());
                if (digit > max) { max = digit; }
                if (digit < min) { min = digit; }
                sum += digit;
            }
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine("{0:f2}", sum/3);
        }
    }
}
