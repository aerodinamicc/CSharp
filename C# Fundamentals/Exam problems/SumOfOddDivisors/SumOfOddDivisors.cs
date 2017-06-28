using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfOddDivisors
{
    class SumOfOddDivisors
    {
        static void Main()
        {
            int A = int.Parse(Console.ReadLine());
            int B = int.Parse(Console.ReadLine());

            int result = 0;

            for (int i = A; i <= B; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if(i%j==0 && j%2 == 1)
                    {
                        result += j;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
