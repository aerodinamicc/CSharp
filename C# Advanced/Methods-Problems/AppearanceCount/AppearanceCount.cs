using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppearanceCount
{
    class AppearanceCount
    {
        static void Count(int[] array, int num)
        {
            int count = 0;
            foreach (int item in array)
            {
                if (item == num)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
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
            int num = int.Parse(Console.ReadLine());
            Count(input, num);
        }
    }
}
