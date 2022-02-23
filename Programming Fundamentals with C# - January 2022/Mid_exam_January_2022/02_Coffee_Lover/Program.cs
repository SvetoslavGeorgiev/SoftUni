using System;
using System.Linq;

namespace _02_Coffee_Lover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coffeeList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var comandsNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < comandsNumber; i++)
            {
                var command = Console.ReadLine()
                    .Split()
                    .ToList();

                var action = command[0];

                switch (action)
                {
                    case "Include":
                        var coffeeBrand = command[1];
                        coffeeList.Add(coffeeBrand);
                        break;
                    case "Remove":
                        var where = command[1];
                        var howManyToRemove = int.Parse(command[2]);

                        if (where == "first")
                        {
                            coffeeList.RemoveRange(0, howManyToRemove);
                        }
                        else
                        {
                            coffeeList.RemoveRange(coffeeList.Count - howManyToRemove, howManyToRemove);
                        }
                        break;
                    case "Prefer":
                        var firstIndex = int.Parse(command[1]);
                        var secondIndex = int.Parse(command[2]);

                        if (firstIndex >= 0 && firstIndex < coffeeList.Count && secondIndex >= 0 && secondIndex < coffeeList.Count && firstIndex > secondIndex)
                        {
                            
                            var value = coffeeList[secondIndex];

                            coffeeList.RemoveAt(secondIndex);
                            coffeeList.Insert(firstIndex, value);

                            value = coffeeList[firstIndex - 1];

                            coffeeList.RemoveAt(firstIndex - 1);

                            coffeeList.Insert(secondIndex, value);
                        }
                        else if (firstIndex >= 0 && firstIndex < coffeeList.Count && secondIndex >= 0 && secondIndex < coffeeList.Count && firstIndex < secondIndex)
                        {
                            var value = coffeeList[firstIndex];

                            coffeeList.RemoveAt(firstIndex);
                            coffeeList.Insert(secondIndex, value);

                            value = coffeeList[secondIndex - 1];

                            coffeeList.RemoveAt(secondIndex - 1);

                            coffeeList.Insert(firstIndex, value);
                        }
                        break;
                    case "Reverse":
                        coffeeList.Reverse();
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffeeList));
        }
    }
}
