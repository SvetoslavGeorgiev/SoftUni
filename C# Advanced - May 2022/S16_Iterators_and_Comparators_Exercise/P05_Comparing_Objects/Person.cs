using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P05_Comparing_Objects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
            Count = 0;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        private int Count { get; set; }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            Console.WriteLine(result);

            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
                Console.WriteLine(result);
            }

            if (result == 0)
            {
                result = Town.CompareTo(other.Town);
                Console.WriteLine(result);
            }

            return result;
        }
    }
}
