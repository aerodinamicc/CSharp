using System;

namespace ConsoleApp1
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        public void Writing(string text)
        {
            Console.WriteLine(text);
        }
    }
}