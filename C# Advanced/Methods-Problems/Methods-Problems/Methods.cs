using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods_Problems
{
    class Methods
    {
        static void MaxNumber(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine(max);

        }
        static void Main()
        {
            string[] line = Console.ReadLine().Split(' ');
            int[] input = new int[3];
            for (int i = 0; i < 3; i++)
            {
                 input[i] = int.Parse(line[i]);
            }
            MaxNumber(input);
        }


    }
}
