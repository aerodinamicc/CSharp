using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ones_and_zeros
{
    class Ones_and_zeros
    {
        static void Main()
        {
            //read input
            int num = int.Parse(Console.ReadLine());
            string binary = Convert.ToString(num, 2).PadLeft(16, '0');

            //logic
            string oneRow0 = ".#.";
            string oneRow1 = "##.";
            string oneRow2 = ".#.";
            string oneRow3 = ".#.";
            string oneRow4 = "###";

            string zeroRow0 = "###";
            string zeroRow1 = "#.#";
            string zeroRow2 = "#.#";
            string zeroRow3 = "#.#";
            string zeroRow4 = "###";

            //extract bits

            //row0
            for (int i = 0; i < binary.Length; i++)
			{
                if (binary[i] - '0' == 1)
                {
                    Console.Write(oneRow0);
                }
                else
                {
                    Console.Write(zeroRow0);
                }
                if (i != binary.Length - 1)
                {
                    Console.Write(".");
                }
                			 
			}
            Console.WriteLine();
            //row1
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] - '0' == 1)
                {
                    Console.Write(oneRow1);
                }
                else
                {
                    Console.Write(zeroRow1);
                }
                if (i != binary.Length - 1)
                {
                    Console.Write(".");
                }

            }
            Console.WriteLine();
            //row2
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] - '0' == 1)
                {
                    Console.Write(oneRow2);
                }
                else
                {
                    Console.Write(zeroRow2);
                }
                if (i != binary.Length - 1)
                {
                    Console.Write(".");
                }

            }
            Console.WriteLine();
            //row3
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] - '0' == 1)
                {
                    Console.Write(oneRow3);
                }
                else
                {
                    Console.Write(zeroRow3);
                }
                if (i != binary.Length - 1)
                {
                    Console.Write(".");
                }

            }
            Console.WriteLine();
            //row4
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] - '0' == 1)
                {
                    Console.Write(oneRow4);
                }
                else
                {
                    Console.Write(zeroRow4);
                }
                if (i != binary.Length - 1)
                {
                    Console.Write(".");
                }

            }
            Console.WriteLine();
        }
    }
}
