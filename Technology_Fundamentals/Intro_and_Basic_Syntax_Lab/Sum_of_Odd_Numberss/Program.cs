using System;

namespace Sum_of_Odd_Numberss
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var sum = 0;
            for (var i = 1; i <= number; i++)
            {
                var oddNumber = 2 * i - 1;
                Console.WriteLine(oddNumber);
                 sum += oddNumber;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
