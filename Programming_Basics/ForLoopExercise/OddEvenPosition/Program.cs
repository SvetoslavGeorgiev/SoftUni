using System;

namespace OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double evenMax = -1000000000.0;
            double oddMin = 1000000000.0;
            double evenMin = 1000000000.0;
            double oddMax = -1000000000.0;

            double sumOdd = 0;
            double sumEven = 0;

            for (int i = 1; i <= n; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    sumOdd += currentNumber;
                    if (currentNumber > oddMax)
                    {
                        oddMax = currentNumber;
                    }
                    if (currentNumber < oddMin)
                    {
                        oddMin = currentNumber;
                    }
                }
                if (i % 2 == 0)
                {
                    sumEven += currentNumber;
                    if (currentNumber > evenMax)
                    {
                        evenMax = currentNumber;
                    }
                    if (currentNumber < evenMin)
                    {
                        evenMin = currentNumber;
                    }
                }
            }

            if (oddMin == 1000000000.0)
            {
                Console.WriteLine($"OddSum={sumOdd:f2}," 
                    + Environment.NewLine + "OddMin=No," 
                    + Environment.NewLine + "OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddSum={sumOdd:f2},"
                    + Environment.NewLine + $"OddMin={oddMin:f2},"
                    + Environment.NewLine + $"OddMax={oddMax:f2},");
            }
            if (evenMin == 1000000000.0)
            {
                Console.WriteLine($"EvenSum={sumEven:f2},"
                    + Environment.NewLine + "EvenMin=No,"
                    + Environment.NewLine + "EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenSum={sumEven:f2},"
                    + Environment.NewLine + $"EvenMin={evenMin:f2},"
                    + Environment.NewLine + $"EvenMax={evenMax:f2}");
            }
        }
    }
}
