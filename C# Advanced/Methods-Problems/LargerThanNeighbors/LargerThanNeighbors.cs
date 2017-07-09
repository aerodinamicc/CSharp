using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargerThanNeighbors
{
    class LargerThanNeighbors
    {
        static void indexNeighbors(int[] array)
        {
            bool notFound = true;
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[i-1] && array[i] > array[i +1])
                {
                    Console.WriteLine(i);
                    notFound = false;
                    break;
                }

            }
            if (notFound)
            {
                Console.WriteLine(-1);
            }

        }
        static void Main()
        {
            int seq = int.Parse(Console.ReadLine());
            string[] line = Console.ReadLine().Split(' ');
            int[] input = new int[seq];
            for (int i = 0; i < seq; i++)
            {
                input[i] = int.Parse(line[i]);
            }
            indexNeighbors(input);
            
        }
    }
}
