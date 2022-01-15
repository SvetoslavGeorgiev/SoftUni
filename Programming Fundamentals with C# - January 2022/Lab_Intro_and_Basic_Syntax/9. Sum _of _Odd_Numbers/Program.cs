using System;

namespace _9._Sum__of__Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var oddNubersToBePrinted = int.Parse(Console.ReadLine());
            var sum = 0;
            for (int i = 0; i < oddNubersToBePrinted * 2; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                    sum += i;
                }
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}