using System;

namespace OddEvenPosition2
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

                if (i % 2 == 0 && evenMax <= currentNumber)
                {
                    evenMax = currentNumber;
                    sumEven += currentNumber;
                }
                else if (i % 2 == 0 && evenMin >= currentNumber)
                {
                    evenMin = currentNumber;
                    sumEven += currentNumber;
                }
                else if (i % 2 != 0 && oddMax <= currentNumber)
                {
                    oddMax = currentNumber;
                    sumOdd += currentNumber;
                }
                else if (i % 2 != 0 && oddMin >= currentNumber)
                {
                    oddMin = currentNumber;
                    sumOdd += currentNumber;
                }
            }

            if (oddMin == 1000000000.0 && oddMax == -1000000000.0)
            {
                Console.WriteLine($"OddSum={sumOdd}"
                    + Environment.NewLine + "OddMin=No"
                    + Environment.NewLine + "OddMax=No");
            }
            else if (oddMin == 1000000000.0 || oddMax == -1000000000.0)
            {
                oddMax = sumOdd;
                oddMin = sumOdd;
                Console.WriteLine($"OddSum={sumOdd}"
                   + Environment.NewLine + $"OddMin={oddMin}"
                   + Environment.NewLine + $"OddMax={oddMax}");
            }
            else
            {
                Console.WriteLine($"OddSum={sumOdd}"
                    + Environment.NewLine + $"OddMin={oddMin}"
                    + Environment.NewLine + $"OddMax={oddMax}");
            }
            if (evenMin == 1000000000.0 && evenMax == -1000000000.0)
            {
                Console.WriteLine($"EvenSum={sumEven}"
                    + Environment.NewLine + "EvenMin=No"
                    + Environment.NewLine + "EvenMax=No");
            }
            else if (evenMin == 1000000000.0 || evenMax == -1000000000.0)
            {
                evenMax = sumEven;
                evenMin = sumEven;
                Console.WriteLine($"EvenSum={sumEven}"
                    + Environment.NewLine + $"EvenMin={evenMin}"
                    + Environment.NewLine + $"EvenMax={evenMax}");
            }
            else
            {
                Console.WriteLine($"EvenSum={sumEven}"
                    + Environment.NewLine + $"EvenMin={evenMin}"
                    + Environment.NewLine + $"EvenMax={evenMax}");
            }
        }
    }
}
