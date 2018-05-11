using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Iterator
{
    public class WashingtonPostIterator : IIterator
    {
        private List<string> _reporters;
        private int _current;

        public WashingtonPostIterator(List<string> reporters)
        {
            this._reporters = reporters;
            _current = 0;
        }

        public void First()
        {
            _current = 0;
        }

        public string Next()
        {
            return _reporters.ElementAt(_current++);

        }

        public bool IsDone()
        {
            return _current >= _reporters.Count;
        }

        public string CurrentItem()
        {
            return _reporters.ElementAt(_current);
        }
    }
}
