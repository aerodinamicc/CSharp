using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTags
{
    class ParseTags
    {
        static void Main()
        {
            string[] line = Console.ReadLine().Split(new string[] { "upcase" }, StringSplitOptions.None);

            for (int i = 0; i < line.Length; i++)
            {
                if (i % 2 == 1)
                {
                    line[i] = line[i].ToUpper();
                }
               line[i] = line[i].Replace(">", "").Replace("</", "").Replace("<", "");
            }
            Console.WriteLine(string.Join("", line));
        }
    }
}
