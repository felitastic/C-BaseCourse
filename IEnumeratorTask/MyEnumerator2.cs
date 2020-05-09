using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumeratorTask
{
    public class MyEnumerator2 : IEnumerator<string>
    {
        private IEnumerator<string> other;
        private int StringCount;
        private int moveCount;

        public string Current => other.Current;

        // brauchen wir nicht
        object IEnumerator.Current => throw new NotImplementedException();

        public MyEnumerator2(IEnumerator<string> arg, int stringCount)
        {
            StringCount = stringCount;
            other = arg;
        }

        // brauchen wir nicht
        public void Dispose()
        {
            // empty um Fehler zu vermeiden
        }

        public bool MoveNext()
        {
            if (moveCount < StringCount)
            {
                moveCount += 1;
                return other.MoveNext();
            }
            return false;
        }

        public void Reset()
        {
            moveCount = 0;
            other.Reset();
        }

    }
}
