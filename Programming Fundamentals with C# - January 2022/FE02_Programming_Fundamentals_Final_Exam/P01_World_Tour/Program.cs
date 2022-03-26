using System;
using System.Linq;

namespace P01_World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var plan = Console.ReadLine();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Travel")
            {

                var tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();


                if (tokens[0].Contains("Add"))
                {
                    var index = int.Parse(tokens[1]);
                    if (index >= plan.Length || index < 0)
                    {
                        Console.WriteLine(plan);
                        continue;
                    }
                    var town = tokens[2];
                    plan = plan.Insert(index, town);
                    Console.WriteLine(plan);

                }
                else if (tokens[0].Contains("Remove"))
                {
                    var indexFrom = int.Parse(tokens[1]);
                    var indexTo = int.Parse(tokens[2]);

                    if (indexFrom >= plan.Length || indexFrom < 0 || indexTo >= plan.Length || indexTo < 0)
                    {
                        Console.WriteLine(plan);
                        continue;
                    }
                    var town = tokens[2];

                    var deference = indexTo - indexFrom;

                    plan = plan.Remove(indexFrom, deference + 1);
                    Console.WriteLine(plan);
                }
                else
                {
                    var townToRemove = tokens[1];
                    var townToAdd = tokens[2];

                    if (!plan.Contains(townToRemove))
                    {
                        Console.WriteLine(plan);
                        continue;
                    }
                    else
                    {
                        plan  = plan.Replace(townToRemove, townToAdd);

                        Console.WriteLine(plan);
                    }
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {plan}");
        }
    }
}
