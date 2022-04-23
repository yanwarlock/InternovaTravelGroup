using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Collections.Concurrent;

namespace Question_3_CustomHashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Question_3");
            var hashTable = new CustomHashSet<Person>();
            var personReferences = new Person("Pepe");
            Console.WriteLine(hashTable.Add(personReferences));
            Console.WriteLine(hashTable.Add(personReferences));
            Console.WriteLine(hashTable.Add(new Person("Maikel")));
        }
    }

    public class Person
    {
        public string Name { get; }

        public Person(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person p1)
            {
                return p1.Name == Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }
    }

    public class CustomHashSet<T>
    {
        private readonly ConcurrentBag<T> _list;
        public CustomHashSet()
        {
            _list = new ConcurrentBag<T>();
        }
        public bool Add(T item)
        {
            if (Contains(item))
            {
                return false;
            }
            _list.Add(item);
            return true;
        }

        public bool Contains(T item)
        {
            return _list.Any(x => ReferenceEquals(x, item) || EqualityComparer<T>.Default.Equals(x, item));
        }
    }
}
