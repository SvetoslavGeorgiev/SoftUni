using System;

namespace _04_Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstInteger = int.Parse(Console.ReadLine());
            var secondInteger = int.Parse(Console.ReadLine());

            var sum = 0;

            for (int i = firstInteger; i <= secondInteger; i++)
            {
                Console.Write($"{i} ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}