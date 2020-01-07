using System;

namespace Divide_without_remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 1; i <= n; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (currentNumber % 2 == 0)
                {
                    p1++;
                }
                if (currentNumber % 3 == 0)
                {
                    p2++;
                }
                if (currentNumber % 4 == 0)
                {
                    p3++;
                }
            }
            Console.WriteLine($"{p1 / n * 100:f2}%"
                + Environment.NewLine + $"{p2 / n * 100:f2}%"
                + Environment.NewLine + $"{p3 / n * 100:f2}%");
        }
    }
}
