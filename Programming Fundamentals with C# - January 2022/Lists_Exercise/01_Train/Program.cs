using System;
using System.Linq;

namespace _01_Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var passengers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var maxCapacity = int.Parse(Console.ReadLine());

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                

                if (command.StartsWith("Add"))
                {
                    var input = command.Split();
                    passengers.Add(int.Parse(input[1]));
                }
                else 
                {
                    var newPassengers = int.Parse(command);

                    for (int i = 0; i < passengers.Count; i++)
                    {
                        if ((passengers[i] + newPassengers) <= maxCapacity)
                        {
                            passengers[i] += newPassengers;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", passengers));
        }
    }
}
