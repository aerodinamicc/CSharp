using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM
{
    class EXAM
    {
        static void Main()
        {
            string line = Console.ReadLine();
            string[] words = line.Split(' ');
            string wordsBackwards = "";
            string wordsBackwardsLow;
            string ModString;

            // I assume the longest word is consisted of 40 letters
            for (int i = 1; i < 40; i++)
            {

                foreach (string word in words)
                {
                    char[] charArray = word.ToCharArray();
                    string newWord = "";
                    if (charArray.Length - i >= 0)
                    {
                        newWord += charArray[charArray.Length - i];
                        wordsBackwards += newWord;
                    }
                }
            }
            

            wordsBackwardsLow = wordsBackwards.ToLower();
            ModString = wordsBackwards;
            for (int i = 0; i < wordsBackwards.Length; i++)
			{
                int ind = wordsBackwardsLow[i] - 96;
                string sym = wordsBackwards[i].ToString();
                //so far so good
                
                ModString = ModString.Insert((ind + i) % ModString.Length, sym);
                if ((ind + i) / ModString.Length > 1 && i > (ind + i) % ModString.Length)
                {
                    i++;
                }

                ModString = ModString.Remove(i, i+1);
                Console.WriteLine(ModString);
                Console.WriteLine((ind + i) % wordsBackwards.Length);
                
			}
            Console.WriteLine(wordsBackwards);
            


        }
    }
}
