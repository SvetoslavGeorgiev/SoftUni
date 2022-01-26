using System;

namespace _01_Integer_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = int.Parse(Console.ReadLine());

            var secondNumber = int.Parse(Console.ReadLine());

            var sum = firstNumber + secondNumber;

            var thirdNumber = int.Parse(Console.ReadLine());

            sum /= thirdNumber;

            var fourthNumber = int.Parse(Console.ReadLine());

            sum *= fourthNumber;

            Console.WriteLine(sum);
        }
    }
}
