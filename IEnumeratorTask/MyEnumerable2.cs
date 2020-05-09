using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumeratorTask
{
    public class MyEnumerable2 : IEnumerable<string>
    {
        private IEnumerable<string> other;
        private int StringCount;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="arg"></param>
        public MyEnumerable2(IEnumerable<string> arg, int stringCount)
        {
            StringCount = stringCount;
            other = arg;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new MyEnumerator2(other.GetEnumerator(), StringCount);
        }

        // brauchen wir nicht
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
