using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] bombAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            List<int> bombPositions = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombAndPower[0])
                {
                    bombPositions.Add(i);
                }
            }
            if (bombPositions.Count > 1)
            {
                for (int i = 0; i < bombPositions.Count; i++)
                {
                    if (i <= bombPositions.Count - 2
                        && bombPositions[i] + bombAndPower[1] >= bombPositions[i + 1])
                    {
                        bombPositions.RemoveRange(bombPositions[i], bombAndPower[1]);
                        
                    }
                }
            }
            

            for (int i = 0; i < bombPositions.Count; i++)
            {
                if (bombPositions[i] + bombAndPower[1] <= numbers.Count - 1)
                {
                    numbers.RemoveRange(bombPositions[i] - bombAndPower[1], bombAndPower[1] * 2 + 1);
                }
                else
                {
                    int deference = (bombAndPower[1] + bombPositions[i]) - (numbers.Count - 1);

                    numbers.RemoveRange(bombPositions[i] - bombAndPower[1],
                        ((bombAndPower[1] * 2) + 1 - deference));

                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
