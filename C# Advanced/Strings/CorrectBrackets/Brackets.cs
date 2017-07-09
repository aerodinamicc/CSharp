using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectBrackets
{
    class Brackets
    {
           static void Main()
        {
            string line = Console.ReadLine();
            char open = '(';
            char close = ')';
            int OpenCount = 0;
            int CloseCount = 0;
            int ind = 0;
            while(OpenCount >= CloseCount && ind < line.Length)
            {
                if (line[ind] == open)
                {
                    OpenCount++;
                }
                else if (line[ind] == close)
                {
                    CloseCount++;
                }
                ind++;
            }

            if (OpenCount == CloseCount)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }
    }
}
