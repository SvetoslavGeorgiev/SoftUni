using System;
using System.Linq;
using System.Collections.Generic;

namespace _05_Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var bombAndPower = Console.ReadLine().Split();
            var bomb = int.Parse(bombAndPower[0]);
            var power = int.Parse(bombAndPower[1]);

            while (numbers.Contains(bomb))
            {
                
                for (int i = 0; i < numbers.Count; i++)
                {
                    var startIndex = 0;
                    var count = 0;
                    var end = 0;
                    if (numbers[i] == bomb)
                    {
                        count = power * 2 + 1;
                        end = numbers.Count - 1 - i;
                        var countToEnd = power + 1 + end;
                        startIndex = Math.Max(0, i - power);
                        count = Math.Min(count, countToEnd);
                        count = Math.Min(count, numbers.Count);
                        numbers.RemoveRange(startIndex, count);
                    }
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}