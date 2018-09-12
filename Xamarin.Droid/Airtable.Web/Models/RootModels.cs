using System;
using System.Collections.Generic;
using System.Text;

namespace Airtable.Web.Models
{
    public class ChoreRootObject
    {
        public List<ChoreRecord> records { get; set; }
    }

    public class ChoreRecord
    {
        public string id { get; set; }
        public ChoreFields fields { get; set; }
        public DateTime createdTime { get; set; }
    }

    public class RecordsRootObject
    {
        public List<RecordTableRecord> records;
    }

    public class RecordTableRecord
    {
        public string id { get; set; }
        public RecordFields fields { get; set; }
        public DateTime createdTime { get; set; }
    }

    
}
