using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumeratorTask
{
    public class MyEnumerator : IEnumerator<string>
    {
        private IEnumerator<string> other;

        public string Current => other.Current;

        // brauchen wir nicht
        object IEnumerator.Current => throw new NotImplementedException();

        public MyEnumerator(IEnumerator<string> arg)
        {
            other = arg;
        }

        // brauchen wir nicht
        public void Dispose()
        {            
            // empty um Fehler zu vermeiden
        }

        public bool MoveNext()
        {
            // wenn 1 true, geht es zu 2, wenn false, gibt es sofort false wieder
            return other.MoveNext() && other.MoveNext();
        }

        public void Reset()
        {
            other.Reset();
        }
        
    }
}
