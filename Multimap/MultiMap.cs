using System;
using System.Collections;
using System.Collections.Generic;

namespace Multimap
{
    public class MultiMap<K, V> : IMultiMap<K, V>
    {
        //all keys
        public IEnumerable<K> Keys => map.Keys;

        //all values
        public IEnumerable<V> Values
        {
            get
            {
                foreach (KeyValuePair<K, List<V>> pair in map)
                {
                    foreach (V value in pair.Value)
                    {
                        yield return value;
                    }
                };
            }
        }

        //all values for ONE key
        public IEnumerable<V> this[K key]
        {
            get
            {
                List<V> tempValues;
                if (map.TryGetValue(key, out tempValues))
                    return tempValues;
                else
                    return new List<V>();
            }
        }

        private Dictionary<K, List<V>> map = new Dictionary<K, List<V>>();

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (KeyValuePair<K, List<V>> pair in map)
            {
                foreach (V value in pair.Value)
                {
                    yield return new KeyValuePair<K, V>(pair.Key, value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(K _key)
        {
            if (map.ContainsKey(_key))
                return true;
            else
                return false;
        }

        public bool ContainsValue(K _key, V _value)
        {
            List<V> tempValues;

            //out is specified in TryGetValue, so programm knows it has to FILL this list with the values it finds
            if (map.TryGetValue(_key, out tempValues))
                return tempValues.Contains(_value);
            else
                return false;
        }

        public void Add(K _key, V _newValue)
        {
            List<V> tempValues;

            if (map.TryGetValue(_key, out tempValues))
            {
                tempValues.Add(_newValue);
            }
            else
            {
                tempValues = new List<V>();
                tempValues.Add(_newValue);
                map.Add(_key, tempValues);
            }
        }

        public void Remove(K _key, V _ValueToRemove)
        {
            List<V> tempValues;

            if (map.TryGetValue(_key, out tempValues))
            {
                if (tempValues.Remove(_ValueToRemove))
                {
                    if (tempValues.Count == 0)
                        map.Remove(_key);
                }
                else
                    Console.WriteLine("The value " + _ValueToRemove + " could not be found in association with " + _key);
            }
            else
            {
                Console.WriteLine("The key " + _key + " could not be found");
            }
        }
    }
}
