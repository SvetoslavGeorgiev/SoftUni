using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfInputs = int.Parse(Console.ReadLine());

            var people = new Dictionary<string, int>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                var person = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                people.Add(person[0], int.Parse(person[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<Dictionary<string, int>, string, int, Dictionary<string, int>> filter = FilterAllPeopleByTheCondition(people, condition, age);

            var newListPleople = 



        }

        private static Func<Dictionary<string, int>, string, int, Dictionary<string, int>> FilterAllPeopleByTheCondition(Dictionary<string, int> people, string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < age;

            }
        }
    }
}
