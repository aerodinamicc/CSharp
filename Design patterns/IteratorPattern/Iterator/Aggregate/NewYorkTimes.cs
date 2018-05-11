using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator.Iterator;

namespace Iterator.Aggregate
{
    public class NewYorkTimes : INewspaper
    {
        private string[] _reporters;

        public NewYorkTimes()
        {
            _reporters = new string[]
            {
                "Greg Hopkins", "Jennifer Pescara", "Quatro Stagioni"
            };
        }

        public IIterator CreateIterator()
        {
            return new NewYorkTimesIterator(_reporters);
        }
    }
}
