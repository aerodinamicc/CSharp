using System;
using System.IO;

namespace ConsoleApp1
{
    public class FileMessageWriter : IMessageWriter
    {
        public void Writing(string text)
        {
            using (StreamWriter writer = new StreamWriter("test.txt"))
            {
                writer.Write(text);
                Console.WriteLine("Succeeded!");
            }
        }
    }
}