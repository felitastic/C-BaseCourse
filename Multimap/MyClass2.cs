using System;

namespace Multimap
{
    public class MyClass2 : MyClass
    {
        public MyClass2(string value) : base(value) { }
        public override string ToString() => String.Format("'{0}'", Value);
    }
}

