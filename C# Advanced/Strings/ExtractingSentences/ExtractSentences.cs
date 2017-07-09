using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractingSentences
{
    class ExtractSentences
    {
        //realno otdelqme izrecheniqta
        // .Trim() za da razkarame spaceovete otpred i otzad
        //namirame non-letter symbols
        //posle vurtim prez vsichki izrecheniq i s .Contains proverqvame dali dumata q ima
        //ako q ima q appendvame s ". "
        static void Main()
        {
            string word = Console.ReadLine();
            //sentences are seprated by dots always. And we split by '.'
            string[] text = Console.ReadLine().Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries); //the last argm gets rid of the empty entries in the array
            StringBuilder PrintedText = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                string sentence = text[i].Trim();
                char[] sep = GetSeparators(sentence);
                string[] words = sentence.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                if (words.Contains(word))
                {
                    PrintedText.Append(text[i] + ".");
                }
            }
            Console.WriteLine(PrintedText);
        }
        static char[] GetSeparators(string line)
        {
            List<char> separators = new List<char>();
            for (int j = 0; j < line.Length; j++)
            {
                if (!Char.IsLetter(line[j]))
                {
                    separators.Add(line[j]);
                }
            }
            char[] sep = separators.ToArray();
            return sep;
        }
    }
}
