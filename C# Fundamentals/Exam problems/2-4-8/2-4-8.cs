using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_4_8
{
    class _2_4_8
    {
        static void Main()
        {
            int fd = Convert.ToInt32(Console.ReadLine());
            int sd = Convert.ToInt32(Console.ReadLine());
            int td = Convert.ToInt32(Console.ReadLine());

            
            int result;
            int Rtrans;
            if (sd == 2)
            {
                result = fd % td;
            }
            else if (sd == 4)
            {
                result = fd + td;
            }
            else
            {
                result = fd * td;
            }

            if (result % 4 == 0)
            {
                Rtrans = result / 4;
            }
            else
            {
                Rtrans = result % 4;
            }
            Console.WriteLine(Rtrans);
            Console.WriteLine(result);
        }
    }
}
