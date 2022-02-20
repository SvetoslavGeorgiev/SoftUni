using System;
using System.Linq;

namespace _04_Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                //if (sequence.Count == 0)
                //{
                //    continue;
                //}
                var input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                var action = input[0];
                var index = int.Parse(input[1]);
                if (action == "Shoot")
                {
                    var power = int.Parse(input[2]);
                    if (index >= 0 && index < sequence.Count)
                    {
                        if (sequence[index] > power)
                        {
                            sequence[index] -= power;
                        }
                        else
                        {
                            sequence.RemoveAt(index);
                        }
                    }
                }
                else if (action == "Add")
                {
                    var value = int.Parse(input[2]);
                    if (index < 0 || index > sequence.Count - 1)
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                    else
                    {
                        sequence.Insert(index, value);
                    }
                }
                else
                {
                    var radius = int.Parse(input[2]);

                    if (index >= 0 && index < sequence.Count)
                    {
                        if (index - radius < 0 || index + radius > sequence.Count - 1)
                        {
                            Console.WriteLine("Strike missed!");
                        }
                        else
                        {
                            var count = radius * 2 + 1;
                            var startIndex = index - radius;
                            sequence.RemoveRange(startIndex, count);
                            
                        }
                    }
                }
            }
            Console.WriteLine(string.Join("|", sequence));
        }
    }
}
