using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Filter_By_Age
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var numberOPeoples = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < numberOPeoples; i++)
            {
                var person = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                people.Add(new Person
                {
                    Name = person[0],
                    Age = int.Parse(person[1])
                });
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<Person, bool> tester = CreateTester(condition, age);

            Action<Person> printer = CreatePrint(format);

            people.Where(tester).ToList().ForEach(printer);
        }

        private static Action<Person> CreatePrint(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine(person.Name);
                case "age":
                    return person => Console.WriteLine(person.Age);
                case "name age":
                    return person => Console.WriteLine($"{person.Name} - {person.Age}");
                default:
                    return null;
            }
        }

        private static Func<Person, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x.Age < age;
                case "older":
                    return x => x.Age >= age;
                default:
                    return null;
            }
        }
    }
}
