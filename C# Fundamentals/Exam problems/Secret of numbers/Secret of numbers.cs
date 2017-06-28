using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secret_of_numbers
{
    class Secret_of_numbers
    {
        static void Main()
        {
            string n = Console.ReadLine();
            int ind = n.Length - 1;
            int total = 0;
            int position = 0;
            for (ind = n.Length - 1; ind >= 0; ind--)
            {
                position += 1;
                int num = n[ind] - '0';
                if (position % 2 == 0)
                {
                    total += (num * num) * position; 
                }
                else
                {
                    total += num * (position*position);
                }
            }
            Console.WriteLine(total);
            if (total % 10 == 0)
            {
                Console.WriteLine("{0} has no secret alpha-sequence", total);
            }
            else
            {
                int SpecLength = total % 10;
                int start = total % 26;
                for (int i = 0; i <= SpecLength; i++)
                {
                    Console.Write("{0}", Convert.ToChar(start + i + 65));
                }
                
            }

        }
    }
}
