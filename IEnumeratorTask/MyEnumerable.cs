using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumeratorTask
{
    public class MyEnumerable : IEnumerable<string>
    {
        private IEnumerable<string> other;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="arg"></param>
        public MyEnumerable(IEnumerable<string> arg)
        {
            other = arg;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new MyEnumerator(other.GetEnumerator());
        }

        // brauchen wir nicht
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
