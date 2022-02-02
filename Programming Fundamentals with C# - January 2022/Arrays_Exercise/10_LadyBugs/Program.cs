using System;
using System.Linq;

namespace _10_LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fieldSize = int.Parse(Console.ReadLine());

            var initialField = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var fieldWithLadyBugs = new int[fieldSize];

            for (int i = 0; i < fieldSize; i++)
            {
                if (initialField.Contains(i))
                {
                    fieldWithLadyBugs[i] = 1;
                }
            }

            var commands = string.Empty;

            while ((commands = Console.ReadLine()) != "end")
            {
                var input = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var flyingFrom = int.Parse(input[0]);
                var flyingDirection = input[1];
                var flyingPower = int.Parse(input[2]);


                if (flyingFrom < 0 || flyingFrom >= fieldSize)
                {
                    continue;
                }
                if (fieldWithLadyBugs[flyingFrom] == 0)
                {
                    continue;
                }
                fieldWithLadyBugs[flyingFrom] = 0;
                var nextFlyingFrom = flyingFrom;

                while (true)
                {
                    if (flyingDirection == "right")
                    {
                        nextFlyingFrom += flyingPower;
                    }
                    else if (flyingDirection == "left")
                    {
                        nextFlyingFrom -= flyingPower;
                    }
                    if (nextFlyingFrom < 0 || nextFlyingFrom >= fieldSize)
                    {
                        break;
                    }
                    if (fieldWithLadyBugs[nextFlyingFrom] == 0)
                    {
                        break;
                    }
                }

                if (nextFlyingFrom >= 0 && nextFlyingFrom < fieldSize)
                {
                    fieldWithLadyBugs[nextFlyingFrom] = 1;
                }
            }
            Console.WriteLine(string.Join(" ", fieldWithLadyBugs));
        }
    }
}
