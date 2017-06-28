using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class Class1
    {
        static void Main()
        {
            string str = Console.ReadLine();
            int fd = str[0] - '0';
            int sd = str[1] - '0';
            int td = str[2] - '0';
            int result;
            int Rtrans;
            if (sd == 3)
            {
                result = fd + td;
            }

            else if (sd == 6)
            {
                result = fd * td;
            }

            else
            {
                result = fd % td;
            }

            if (result % 3 == 0)
            {
                Rtrans = result / 3;
            }
            else
            {
                Rtrans = result % 3;
            }

            Console.WriteLine(Rtrans);
            Console.WriteLine(result);
        }
    }
}

