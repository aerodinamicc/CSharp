using Airtable.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Airtable.Web
{
    public static class StandingsCalculator
    {
        //key is the unique Chore identifier and two values in the list are: 1) Name, 2) weight of the Chore.
        private static Dictionary<string, double> weights = new Dictionary<string, double>();

        private static Dictionary<string, string> ChoresMap = new Dictionary<string, string>();

        public static Dictionary<string, Dictionary<string, double>> resultsByCategory = new Dictionary<string, Dictionary<string, double>>()
        {
            { "Daniusha", new Dictionary<string, double>() },
            { "Zlatko", new Dictionary<string, double>() }
        };

        public static Dictionary<string, double> resultsOverall = new Dictionary<string, double>
        {
            { "Daniusha", 0 },
            { "Zlatko", 0 }
        };

        public static void CalculateResults(List<RecordTableRecord> recordsList, bool dailyResult = false)
        {
            foreach (var participant in resultsByCategory.Keys)
            {
                //get all records of a participant
                var participantRecords = recordsList.Where(r => r.fields.Participant == participant).ToList();

                if (dailyResult)
                {
                    var today = DateTime.Now.Date;
                    participantRecords = participantRecords.Where(r => r.createdTime.Date == today).ToList();
                }

                //sum all records by category
                foreach (var record in participantRecords)
                {
                    var choreIdentifier = record.fields.Chore[0]; 
                    var choreName = ChoresMap[choreIdentifier];
                    var choreWeight = weights[choreName];
                    var points = record.fields.Points;
                    var result = points * choreWeight;

                    resultsByCategory[participant][choreName] += result;
                    resultsOverall[participant] += result;

                    if (!resultsByCategory.ContainsKey("Overall"))
                    {
                        resultsByCategory.Add(participant, new Dictionary<string, double> { { "Overall", 0 } });
                    }
                    resultsByCategory[participant]["Overall"] += result;
                }
            }
        }

        public static void GetChoreWeights(List<ChoreRecord> choresList)
        {
            foreach (var chore in choresList)
            {
                weights.Add(chore.fields.Name, chore.fields.Weight);

                //we need a map because the reference in Airtable keep the unique identifier and not directly the value of Chore
                ChoresMap.Add(chore.id, chore.fields.Name);

                //initiating the Chores in resultByCategory
                foreach (var participant in resultsByCategory.Keys)
                {
                    resultsByCategory[participant].Add(chore.fields.Name, 0);
                }
            }
        }

        public static string GetChoreIdentifierByName(string identifier)
        {
            return ChoresMap.FirstOrDefault(x => x.Value == identifier).Key;
        }
    }
}
