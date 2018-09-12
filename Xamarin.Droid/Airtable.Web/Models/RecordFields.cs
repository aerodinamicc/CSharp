using Newtonsoft.Json;
using System.Collections.Generic;

namespace Airtable.Web.Models
{
    public class RecordFields
    {
        [JsonIgnore]
        public int Id { get; set; }

        public List<string> Chore { get; set; }

        public string Participant { get; set; }

        public double Points { get; set; }
    }
}
