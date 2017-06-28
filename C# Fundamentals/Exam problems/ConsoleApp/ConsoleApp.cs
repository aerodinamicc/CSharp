using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApp
{
    class ConsoleApp
    {
        static void Main()
        {
            string num = "0";
            int position = 0;
            long product = 1;
            BigInteger result = 1;
            BigInteger resultSec = 1;

            while (num != "END" && position < 10)
            {
                num = Console.ReadLine();
                if (position%2 == 1)
                {
                    foreach (char digit in num)
                    {
                        if (digit == '0') { product *= 1; }
                        else { product *= (long)Char.GetNumericValue(digit); }
                    }
                    result *= product;
                    product = 1;
                }
                
                position++;
            }
            

            while (num != "END" && position >= 10)
            {
                num = Console.ReadLine();
                if (position%2 == 1)
                {
                    foreach (char digit in num)
                    {
                        if (digit == '0') { product *= 1; }
                        else {product *= (long) Char.GetNumericValue(digit);}
                    }
                    resultSec *= product;
                    product = 1;
                }
                
                position++;
            }
            Console.WriteLine(result - 0);
            if (position >= 10) { Console.WriteLine(resultSec); }

        }
    }
}
