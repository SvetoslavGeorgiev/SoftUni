using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var family = new List<Person>();
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var line = Console.ReadLine().Split();

                var name = line[0];
                var age = int.Parse(line[1]);

                family.Add(new Person(name, age));
            }

            foreach (var person in family.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
