using System;
using System.Linq;

namespace _06_Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var evenSum = 0;
            var oddSum = 0;
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenSum += number;
                }
                else
                {
                    oddSum += number;
                }
            }
            Console.WriteLine(evenSum - oddSum);
        }
    }
}