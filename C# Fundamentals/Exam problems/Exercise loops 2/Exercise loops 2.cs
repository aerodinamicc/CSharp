using System;

public class Solution
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        
        if (num > 1)
        {
            int min = int.Parse(Console.ReadLine());
            int max = min;
            int sum = max;
            

            for (int i = 1; i < num; i++)
            {
                int temp = int.Parse(Console.ReadLine());
                if (min > temp)
                {
                    min = temp;
                }
                if (temp > max)
                {
                    max = temp;
                }
                sum += temp;
            }
            Console.WriteLine("min={0:f2}", min);
            Console.WriteLine("max={0:f2}", max);
            Console.WriteLine("sum={0:f2}", sum);
            Console.WriteLine("avg={0:f2}", (double)sum / num);
        }
        if (num == 1)
        {
            int n = int.Parse(Console.ReadLine());   
            Console.WriteLine("min={0:F2}", n);
            Console.WriteLine("max={0:F2}", n);
            Console.WriteLine("sum={0:F2}", n);
            Console.WriteLine("avg={0:F2}", (double) n);
        }
    }
}