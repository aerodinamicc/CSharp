using AirtableWeb;
using AirtableWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StandingsCalculator.CalculateResults();
            AirtableHandler.SendRecord(new RecordFields
            {
                Chore = new List<string>()
                {
                    { StandingsCalculator.GetChoreIdentifierByName("Bathroom") }
                },
                Participant = "Zlatko",
                Points = 1
            });

            AirtableHandler.SendRecord(new RecordFields
            {
                Chore = new List<string>()
                {
                    { StandingsCalculator.GetChoreIdentifierByName("Laundry") }
                },
                Participant = "Daniusha",
                Points = 1
            });

            Console.ReadKey();
        }
    }
}
