using AirtableWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirtableWeb
{
    public static class StandingsCalculator
    {
        //key is the unique Chore identifier and two values in the list are: 1) Name, 2) weight of the Chore.
        private static Dictionary<string, double> weights = new Dictionary<string, double>();

        private static Dictionary<string, string> ChoresMap = new Dictionary<string, string>();

        private static Dictionary<string, List<KeyValuePair<string, double>>> resultsByCategory = new Dictionary<string, List<KeyValuePair<string, double>>>()
        {
            { "Daniusha", new List<KeyValuePair<string, double>>() },
            { "Zlatko", new List<KeyValuePair<string, double>>() }
        };

        private static void GetChoreWeights()
        {
            var choresList = AirtableHandler.GetChores().GetAwaiter().GetResult().records;

            foreach (var chore in choresList)
            {
                weights.Add(chore.fields.Name, chore.fields.Weight);

                //we need a map because the reference in Airtable keep the unique identifier and not directly the value of Chore
                ChoresMap.Add(chore.id, chore.fields.Name);

                //initiating the Chores in resultByCategory
                foreach (var participant in ResultsByCategory.Keys)
                {
                    ResultsByCategory[participant].Add(new KeyValuePair<string, double>(chore.fields.Name, 0));
                }
            }
        }

        public static Dictionary<string, List<KeyValuePair<string, double>>> ResultsByCategory
        {
            get
            {
                return resultsByCategory;
            }

            private set { }
        }

        public static List<string> Chores
        {
            get
            {
                return ChoresMap.Values.ToList();
            }

            private set { }
        }

        public static List<string> Participants
        {
            get
            {
                return resultsByCategory.Keys.ToList();
            }
            private set { }
        }

        public static void CalculateResults(bool dailyResult = false)
        {
            var records = AirtableHandler.GetRecords();
            var recordsList = records.Result.records;
            GetChoreWeights();

            foreach (var participant in ResultsByCategory.Keys)
            {
                //get all records of a participant
                var participantRecords = recordsList.Where(r => r.fields.Participant == participant).ToList();

                if (dailyResult)
                {
                    var today = DateTime.Now.Date;
                    participantRecords = participantRecords.Where(r => r.createdTime.Date == today).ToList();
                }

                int overallIndex = 0;

                //sum all records by category
                foreach (var record in participantRecords)
                {
                    var choreIdentifier = record.fields.Chore[0];
                    var choreName = ChoresMap[choreIdentifier];
                    var choreWeight = weights[choreName];
                    var points = record.fields.Points;
                    var result = points * choreWeight;

                    var choreIndex = ResultsByCategory[participant].FindIndex(x => x.Key == choreName);
                    var choreToUpdate = ResultsByCategory[participant][choreIndex];
                    ResultsByCategory[participant][choreIndex]= new KeyValuePair<string, double>(choreToUpdate.Key, choreToUpdate.Value + result);

                    if (!ResultsByCategory[participant].Any(x => x.Key == "Overall"))
                    {
                        ResultsByCategory[participant].Add(new KeyValuePair<string, double>("Overall", 0));
                        overallIndex = ResultsByCategory[participant].FindIndex(x => x.Key == "Overall");
                    }
                    ResultsByCategory[participant][overallIndex] = new KeyValuePair<string, double>(ResultsByCategory[participant][overallIndex].Key,
                                                                                                    ResultsByCategory[participant][overallIndex].Value + result);
                }
            }
        }

        public static string GetChoreIdentifierByName(string identifier)
        {
            return ChoresMap.FirstOrDefault(x => x.Value == identifier).Key;
        }
    }
}
