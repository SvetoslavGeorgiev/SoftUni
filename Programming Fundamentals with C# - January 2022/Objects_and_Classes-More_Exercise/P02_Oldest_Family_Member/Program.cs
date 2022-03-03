using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var numberOfPeople = int.Parse(Console.ReadLine());

            var newFamaly = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                var person = new Person(name, age);

                newFamaly.AddMember(person);

            }

            var oldestPerson = newFamaly.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
            
        }

        public class Person
        {
            public Person()
            {
                
            }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
            
        }

        public class Family
        {
            public Family()
            {
                ListOfPeople = new List<Person>();
            }
            public Family(List<Person> listOfPeople)
            {
                ListOfPeople = listOfPeople;
            }
            public List<Person> ListOfPeople { get; set; }

            public void AddMember(Person member)
            {
                ListOfPeople.Add(member);
            }

            public Person GetOldestMember()
            {

                return ListOfPeople.OrderByDescending(p => p.Age).First();
            }
        }
    }
}
                                                                                                                                                                                                                                  