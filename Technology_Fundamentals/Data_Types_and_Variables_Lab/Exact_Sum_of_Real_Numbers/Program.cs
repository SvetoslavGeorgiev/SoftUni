using System;

namespace Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = int.Parse(Console.ReadLine());

            decimal sum = 0;

            for (int i = 1; i <= numbers; i++)
            {
                var number = decimal.Parse(Console.ReadLine());

                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}
