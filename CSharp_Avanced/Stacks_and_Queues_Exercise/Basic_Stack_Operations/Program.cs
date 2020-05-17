using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> leftNumbers = new Stack<int>();

            for (int i = 0; i <= input[0] - 1; i++)
            {
                leftNumbers.Push(numbers[i]);
            }

            var countOfNumbersToPop = Math.Min(input[1], leftNumbers.Count);

            for (int i = 1; i <= countOfNumbersToPop; i++)
            {
                leftNumbers.Pop();
            }

            if (leftNumbers.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else if (leftNumbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                var smallestNumber = int.MaxValue;
                while (leftNumbers.Any())
                {
                    var currentNumber = leftNumbers.Pop();
                    if (currentNumber < smallestNumber)
                    {
                        smallestNumber = currentNumber;
                    }
                }

                Console.WriteLine($"{smallestNumber}");

            }
        }
    }
}
