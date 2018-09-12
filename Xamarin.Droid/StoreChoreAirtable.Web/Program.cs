using Airtable.Web;
using Airtable.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace StoreChoreAirtable.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var chores = AirtableHandler.GetChores();
            var records = AirtableHandler.GetRecords();
            StandingsCalculator.GetChoreWeights(chores.Result.records);
            StandingsCalculator.CalculateResults(records.Result.records, true);
            AirtableHandler.SendRecord(new RecordFields
            {
                Chore = new List<string>()
                {
                    { StandingsCalculator.GetChoreIdentifierByName("Bathroom") }
                },
                Participant = "Zlatko",
                Points = 1
            });
        }
    }
}
