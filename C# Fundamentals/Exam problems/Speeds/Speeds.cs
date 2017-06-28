using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speeds
{
    class Speeds
    {
        static void Main()
        {
            int cars = int.Parse(Console.ReadLine());
            double maxLine = 0;
            double maxSpeed = 0;
            double curent = 0;
            double curentLine = 0;
            double curentSpeed = 0;
            double exSpeed = 0;
            for (int i = 0; i < cars; i++)
            {

                curent = double.Parse(Console.ReadLine());
                if (i == 0)
                {
                    exSpeed = curent;
                }
                if (curent > exSpeed)
                {
                    curentSpeed += curent;
                    curentLine++;
                }
                else
                {
                    exSpeed = curent;
                    curentLine = 1;
                    curentSpeed = curent;
                }
                if (curentLine > maxLine)
                {
                    maxLine = curentLine;
                    maxSpeed = curentSpeed;
                }
                else if ((curentLine == maxLine) && (curentSpeed > maxSpeed))
                {
                    maxSpeed = curentSpeed;
                }

            }
            Console.WriteLine(maxSpeed);
        }
    }
}
