using System;

namespace Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = int.Parse(Console.ReadLine());
            var stop = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = start; i <= stop; i++)
            {
                Console.Write($"{i} ");
                sum += i;
            }
            Console.WriteLine("");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
