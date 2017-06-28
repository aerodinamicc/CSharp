using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_exercises
{
    class Loops_exercises
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int lastIndex = numbers.Length - 1;
            bool sym = true;
            for (int i = 0; i <= lastIndex; i++)
            {
                if (numbers[i] != numbers[lastIndex - i])
                {
                    sym = false;
                    break;
                }
            }
          
            if (sym)
            {
                Console.WriteLine("Symetric");
            }
            else
            {
                Console.WriteLine("NOT Symetric");
            }
        }
    }
}
