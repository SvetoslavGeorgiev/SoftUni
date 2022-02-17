using System;
using System.Linq;
using System.Collections.Generic;

namespace _09_Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var sum = 0;
            while (input.Any())
            {
                var isInList = true;
                var index = int.Parse(Console.ReadLine());
                var indexHolder = index;
                if (index < 0 || index > input.Count - 1)
                {
                    isInList = false;
                }
                index = Math.Min(index, input.Count - 1);
                index = Math.Max(index, 0);
                var removedNumber = input[index];
                sum += removedNumber;
                if (isInList)
                {
                    input.RemoveAt(index);
                }
                else if(indexHolder > input.Count - 1)
                {
                    input[index] = input[0];
                }
                else
                {
                    input[0] = input[input.Count-1];
                }

                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] <= removedNumber)
                    {
                        input[i] += removedNumber;
                    }
                    else
                    {
                        input[i] -= removedNumber;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
