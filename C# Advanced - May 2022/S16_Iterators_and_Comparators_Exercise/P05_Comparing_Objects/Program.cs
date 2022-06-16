using System;
using System.Collections.Generic;

namespace P05_Comparing_Objects
{
    public class Program
    {
        static void Main(string[] args)
        {

            var command = string.Empty;

            var people = new List<Person>();

            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split();

                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];

                var person = new Person(name, age, town);

                people.Add(person);


            }
            var indexOfThePersonToCompare = int.Parse(Console.ReadLine()) - 1;

            var equalPeople = 0;

            for (int i = 0; i < people.Count; i++)
            {

                var result = people[indexOfThePersonToCompare].CompareTo(people[i]);

                if (result == 0)
                {
                    equalPeople++;
                }

            }

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {people.Count - equalPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
            

        }
    }
}
