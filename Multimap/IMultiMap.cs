using System;
using System.Collections;
using System.Collections.Generic;

namespace Multimap
{
    public interface IMultiMap<K,V> : IEnumerable<KeyValuePair<K, V>>
    {
        IEnumerable<K> Keys { get; }
        IEnumerable<V> Values { get; }
        IEnumerable<V> this[K key] { get; }

        bool ContainsKey(K _key);

        bool ContainsValue(K _key, V _value);

        void Add(K _key, V _newValue);

        void Add<K2,V2>(IMultiMap<K2, V2> newMultiMap) 
            where K2: K 
            where V2: V;

        void Remove(K _key, V _ValueToRemove);        

    }

}

