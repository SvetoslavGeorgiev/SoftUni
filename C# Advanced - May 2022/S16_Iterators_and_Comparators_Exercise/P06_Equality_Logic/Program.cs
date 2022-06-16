using System;
using System.Collections.Generic;

namespace P06_Equality_Logic
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sortetSet = new SortedSet<Person>();

            var hasSet = new HashSet<Person>();

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {

                var tokens  = Console.ReadLine().Split();

                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                var person = new Person(name, age);

                sortetSet.Add(person);
                hasSet.Add(person);
            }

            Console.WriteLine(sortetSet.Count);
            Console.WriteLine(hasSet.Count);
        }
    }
}
