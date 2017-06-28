using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoding
{
    class Decoding
    {
        static void Main()
        {
            int salt = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            double value;
            int position = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '@') { break;}
                if (Char.IsLetter(line[i]))
                {
                    value = (int)line[i] * salt + 1000;
                }
                else if (Char.IsDigit(line[i]))
                {
                    value = (int)line[i] + salt + 500;
                }
                else
                {
                    value = (int)line[i] - salt;
                }

                if (i % 2 == 0)
                {
                    Console.WriteLine("{0:f2}",value /= 100); 
                }
                else if(i % 2 == 1)
                {
                    Console.WriteLine(value *= 100); 
                }
            }
        }
    }
}
