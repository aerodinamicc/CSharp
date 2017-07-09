using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    class SubStringInText
    {
        static void Main()
        {
            string pattern = Console.ReadLine().ToLower();
            string line = Console.ReadLine().ToLower();

            int index = line.IndexOf(pattern);
            int count = 0;
            while (index != -1)
            {
                index = line.IndexOf(pattern, index);
                
                if (index == -1)
                {
                    break;
                }
                else
                {
                    count++;
                    index++; //in order to go one step further than the index
                }
            }
            Console.WriteLine(count);
        }
    }
}
