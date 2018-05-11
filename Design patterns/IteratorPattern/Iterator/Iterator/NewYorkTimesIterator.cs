using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Iterator
{
    class NewYorkTimesIterator : IIterator
    {
        private string[] _reporters;
        private int _current;

        public NewYorkTimesIterator(string[] reporters)
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
            return _reporters[_current++];
        }

        public bool IsDone()
        {
            return _current >= _reporters.Length;
        }

        public string CurrentItem()
        {
            return _reporters[_current];
        }
    }
}
