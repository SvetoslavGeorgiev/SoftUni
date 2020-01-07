using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 1; i <= n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 200)
                {
                    p1++;
                }
                else if (currentNumber >= 200 && currentNumber < 400)
                {
                    p2++;
                }
                else if (currentNumber >= 400 && currentNumber < 600)
                {
                    p3++;
                }
                else if (currentNumber >= 600 && currentNumber < 800)
                {
                    p4++;
                }
                else
                {
                    p5++;
                }
            }
            Console.WriteLine($"{p1 / n * 100:f2}%"
                + Environment.NewLine + $"{p2 / n * 100:f2}%"
                + Environment.NewLine + $"{p3 / n * 100:f2}%"
                + Environment.NewLine + $"{p4 / n * 100:f2}%"
                + Environment.NewLine + $"{p5 / n * 100:f2}%");
        }
    }
}
