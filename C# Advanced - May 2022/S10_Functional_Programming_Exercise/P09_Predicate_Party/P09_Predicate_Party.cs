using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_Predicate_Party
{
    public class P09_Predicate_Party
    {
        static void Main()
        {
            var listOfPeople = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {

                var criterias = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                Predicate<string> pr = Cheker(criterias);

                if (criterias[0] == "Remove")
                {
                    listOfPeople.RemoveAll(pr);
                }
                else if (criterias[0] == "Double")
                {
                    var matches = listOfPeople.FindAll(pr);
                    if (matches.Count > 0)
                    {
                        var index = listOfPeople.FindIndex(pr);
                        listOfPeople.InsertRange(index, matches);
                    }
                }

            }

            if (listOfPeople.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", listOfPeople) + " are going to the party!");
            }
        }

        private static Predicate<string> Cheker(List<string> criterias)
        {
            if (criterias[1] == "StartsWith")
            {
                return x => x.StartsWith(criterias[2]);

            }
            else if (criterias[1] == "EndsWith")
            {
                return x => x.EndsWith(criterias[2]);
            }
            else if (criterias[1] == "Length")
            {
                return x => x.Length == int.Parse(criterias[2]);
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }
        }
    }
}
