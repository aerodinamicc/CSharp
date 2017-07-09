using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double num = double.Parse(Console.ReadLine());
                if(num < 0)
                {
                    //the exception object is declared here
                    throw new ArgumentOutOfRangeException("Invalid number");
                }
                Console.WriteLine("{0:f3}",Math.Sqrt(num));
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
