using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2number
{
    class Text2number
    {
        static void Main()
        {
            int module = int.Parse(Console.ReadLine());
            string line = Console.ReadLine().ToUpper();
            
            int i = 0;
            int result = 0;

            while(line[i] != '@')
            {
                if(Char.IsDigit(line[i]))
                {
                    result *= line[i] - '0';
                }
                else if (Char.IsLetter(line[i]))
                {
                    result += (int) line[i] - 65;
                }
                else
                {
                    result = result % module;
                }
                i++;
            }
            Console.WriteLine(result);
        }
    }
}
