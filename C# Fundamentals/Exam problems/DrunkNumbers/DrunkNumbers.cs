using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkNumbers
{
    class DrunkNumbers
    {
        static void Main()
        {
            int round = int.Parse(Console.ReadLine());
             int m = 0;
            int v = 0;

            for (int i = 0; i < round; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    number *= -1;
                }

                int digits = 0;
                int tempNumber = number;

                while(tempNumber != 0)
                {
                    tempNumber /= 10;
                    digits++;
                }
                
                if(digits%2 == 0)
                {
                    for (int s = 0; s < digits/2; s++)
                    {
                        v += number % 10;
                        number /= 10;
                    }
                    for (int j = 0; j < digits/2; j++)
                    {
                        m += number % 10;
                        number /= 10;
                    }
                }
                else if (digits%2 == 1)
                {
                    for (int s = 0; s < digits / 2; s++)
                    {
                        v += number % 10;
                        number /= 10;
                    }
                    int mid = number % 10;
                    number /= 10;
                    v += mid;
                    m += mid;
                    for (int j = 0; j < digits / 2; j++)
                    {
                        m += number % 10;
                        number /= 10;
                    }
                }

            }
            if(m>v)
            {
                Console.WriteLine("M {0}", m-v);
            }
            else if(v>m)
            {
                Console.WriteLine("V {0}", v-m);
            }
            else
            {
                Console.WriteLine("No {0}", m+v);
            }

        }
    }
}
