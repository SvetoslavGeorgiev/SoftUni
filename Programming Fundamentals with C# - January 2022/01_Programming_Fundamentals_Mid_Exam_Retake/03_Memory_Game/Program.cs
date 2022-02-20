using System;
using System.Linq;

namespace _03_Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var command = string.Empty;
            var movesCounter = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                movesCounter++;
                var indexes = command.Split();
                var firstIndex = int.Parse(indexes[0]);
                var secondIndex = int.Parse(indexes[1]);
                var middleOfTheSequence = sequence.Count / 2;

                if (firstIndex == secondIndex || firstIndex < 0 || secondIndex < 0 || firstIndex > sequence.Count - 1 || secondIndex > sequence.Count - 1)
                {
                    sequence.Insert(middleOfTheSequence, $"-{movesCounter}a");
                    sequence.Insert(middleOfTheSequence, $"-{movesCounter}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    continue;
                }
                if (sequence[firstIndex] == sequence[secondIndex])
                {
                    if (firstIndex > secondIndex)
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {sequence[firstIndex]}!");
                        sequence.RemoveAt(firstIndex);
                        sequence.RemoveAt(secondIndex);
                    }
                    else
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {sequence[firstIndex]}!");
                        sequence.RemoveAt(secondIndex);
                        sequence.RemoveAt(firstIndex);
                    }
                }
                else
                {
                    Console.WriteLine("Try again!");
                }
                if (sequence.Count == 0)
                {
                    Console.WriteLine($"You have won in {movesCounter} turns!");
                    return;
                }
            }
            if (sequence.Any())
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", sequence));
            }
        }
    }
}
