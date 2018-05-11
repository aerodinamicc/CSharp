using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator.Iterator;

namespace Iterator.Aggregate
{
    public class WashingtonPost : INewspaper
    {
        private List<string> _reporters;

        public WashingtonPost()
        {
            _reporters = new List<string>
            {
                "Matt Smith", "Jully Howkins", "Vera DeMillo"
            };
        }

        public IIterator CreateIterator()
        {
            return new WashingtonPostIterator(_reporters);
        }
    }
}
