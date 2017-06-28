using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angry_Female_GPS
{
    class Angry_Female_GPS
    {
        static void Main()
        {
            string str = Console.ReadLine();
            int ind = 0;
            int odd = 0;
            int even = 0;
            string direction = "";
            for (ind = 0; ind < str.Length; ind++)
            {
                int num = str[ind] - '0';
                if (ind % 2 == 0)
                {
                    even += num;
                }
                else
                {
                    odd += num;
                }
            }
            if (even > odd)
            {
                direction = "right";
                Console.WriteLine("{0} {1}", direction, even);
            }
            else if (odd > even)
            {
                direction = "left";
                Console.WriteLine("{0} {1}", direction, odd);
            }
            else
            {
                direction = "straight";
                Console.WriteLine("{0} {1}", direction, even);
            }
            
        }
    }
}
