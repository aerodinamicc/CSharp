using System;

public class Solution
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());
        double sum = 1;
        double factorial = 1;
        double power = 1;
        
        for (int i = 1; i <= num; i++)
        {
            factorial *= i;
            power *= x;
            sum += factorial / power;
        }
        Console.WriteLine("{0:f5}", sum);
    }
}