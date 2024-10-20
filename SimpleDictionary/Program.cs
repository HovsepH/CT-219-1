using System;
using System.Collections.Generic;

public class Dictionary<TKey, TValue>
{
    private HashTable<TKey, TValue> _hashTable;

    public Dictionary()
    {
        _hashTable = new HashTable<TKey, TValue>();
    }

    public void AddPair(TKey key, TValue value)
    {
        var pair = new KeyValuePair<TKey, TValue>(key, value);
        _hashTable.AddPair(pair);
    }

    public void PrintContent()
    {
        _hashTable.PrintTable();
    }
}

public class HashTable<TKey, TValue>
{
    private List<KeyValuePair<TKey, TValue>>[] _table;
    private int _filledBuckets;

    public HashTable()
    {
        _filledBuckets = 0;
        _table = new List<KeyValuePair<TKey, TValue>>[16];
    }

    public void AddPair(KeyValuePair<TKey, TValue> pair)
    {
        int hashCode = GenerateHash(pair.Key);
        int index = Math.Abs(hashCode % _table.Length);

        AddToBucket(index, pair);
        ResizeTableIfNeeded();
    }

    private void AddToBucket(int index, KeyValuePair<TKey, TValue> pair)
    {
        var bucket = _table[index];

        if (bucket == null)
        {
            bucket = new List<KeyValuePair<TKey, TValue>>();
            _table[index] = bucket;
            _filledBuckets++;
        }

        bool replaced = false;
        for (int i = 0; i < bucket.Count; i++)
        {
            if (bucket[i].Key.Equals(pair.Key))
            {
                bucket[i] = new KeyValuePair<TKey, TValue>(pair.Key, pair.Value); 
                replaced = true;
                break;
            }
        }

        if (!replaced)
        {
            bucket.Add(pair);  
        }
    }

    private void ResizeTableIfNeeded()
    {
        float loadFactor = (float)_filledBuckets / _table.Length;

        if (loadFactor >= 0.75f)
        {
            var oldTable = _table;
            _table = new List<KeyValuePair<TKey, TValue>>[oldTable.Length * 2];
            _filledBuckets = 0;

            foreach (var bucket in oldTable)
            {
                if (bucket != null)
                {
                    foreach (var pair in bucket)
                    {
                        AddPair(pair); 
                    }
                }
            }
        }
    }

    public void PrintTable()
    {
        for (int i = 0; i < _table.Length; i++)
        {
            var bucket = _table[i];
            if (bucket != null)
            {
                Console.WriteLine($"Bucket {i}:");
                foreach (var pair in bucket)
                {
                    Console.WriteLine($"  {pair.Key} => {pair.Value}");
                }
            }
        }
    }

    private int GenerateHash(TKey key)
    {
        return key.GetHashCode();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var dictionary = new Dictionary<string, string>();
        dictionary.AddPair("car", "vehicle");
        dictionary.AddPair("car", "updated vehicle");

        dictionary.PrintContent();
    }
}
