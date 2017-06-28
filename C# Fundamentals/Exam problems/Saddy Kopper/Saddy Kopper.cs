using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Saddy_Kopper
{
    class Saddy_Kopper
    {
        static void Main()
        {
            string str = "2613994514047494"; //Console.ReadLine();
            int transCount = 0;
            while (str.Length > 1 && transCount < 10)
            { 
                BigInteger product = 1;
                while (str.Length > 0)
                {
                    str = str.Substring(0, str.Length - 1);
                    int sum = 0;
                    for (int ind = 0; ind < str.Length; ind += 2)
                    {
                        sum += (str[ind] - '0');
                    }
                    product *= sum != 0 ? sum : 1;
                }
                transCount++;
                str = product.ToString();
            }
            if (transCount < 10)
            {
                Console.WriteLine(transCount);
            }
            Console.WriteLine(str);
        }
    }
}
