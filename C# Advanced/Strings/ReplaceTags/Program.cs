using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceTags
{
    class Program
    {
        static void Main(string[] args)
        {
            //the last argm gets rid of the empty entries in the array
            //StringSplitOptions.None mi reshi zadachata StringSplitOptions.RemoveEmptySpaces dava razlichen masiv
            string[] text = Console.ReadLine().Split(new string[] { "<a href=\"", "</a>" }, StringSplitOptions.None);
            StringBuilder final = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 == 1)
                {
                    string[] temp = text[i].Split(new string[] { "\">" }, StringSplitOptions.None);
                    string Reaaranged = String.Format("[{0}]({1})", temp[1], temp[0]);
                    final.Append(Reaaranged);
                }
                else
                {
                    final.Append(text[i]);
                }
            }
            Console.WriteLine(final.ToString());

        }
    }
}
