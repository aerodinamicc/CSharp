using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piece_of_cake
{
    class Piece_of_cake
    {
        static void Main()
        {
            int A = Convert.ToInt32(Console.ReadLine());
            int B = Convert.ToInt32(Console.ReadLine());
            int C = Convert.ToInt32(Console.ReadLine());
            int D = Convert.ToInt32(Console.ReadLine());
            double result = (double) ((double)A/(double)B) + ((double)C/(double)D);
            
            if (result > 1)
            {
                Console.WriteLine((int) result);
                Console.WriteLine((A * D + C * B) + "/" + B * D);
            }
            else
            {
                Console.WriteLine("{0:0.000000000000000000000}", result);
            }

        }
    }
}
