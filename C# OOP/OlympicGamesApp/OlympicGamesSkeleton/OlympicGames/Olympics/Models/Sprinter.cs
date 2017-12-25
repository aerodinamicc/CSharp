using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Olympics.Models
{
    class Sprinter : Olympian, IOlympian, ISprinter, ICountry
    {
        private IDictionary<string, double> personalRecords;

        public Sprinter(string firstName, string lastName, string country,
            IDictionary<string, double> personalRecords)
            : base(firstName, lastName, country)
        {
            this.PersonalRecords = personalRecords;
        }

        public IDictionary<string, double> PersonalRecords
        {
            get
            {
                return this.personalRecords;
            }
            private set
            {
                this.personalRecords = value;
            }
        }


        public string DictionaryToString(IDictionary<string, double> dict)
        {
            StringBuilder line = new StringBuilder();
            foreach (var item in this.PersonalRecords)
            {
                line.Append($"{item.Key}m: " + $"{item.Value}s" + "\n");
            }
            line.Length -= 1;
            return line.ToString();
        }

        public override string ToString()
        {
            string personalRec;
            if (this.personalRecords.Count < 1)
            {
                personalRec = GlobalConstants.NoPersonalRecordsSet;
            }
            else
            {
                personalRec = $"PERSONAL RECORDS:\n" +
                              DictionaryToString(personalRecords);
            }

            return $"SPRINTER: {base.FirstName} {base.LastName} from {base.Country}\n" +
                   $"{personalRec}";
                                 

            
        }
    }
}
