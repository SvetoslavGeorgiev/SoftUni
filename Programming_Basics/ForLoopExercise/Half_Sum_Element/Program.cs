using System;

namespace Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int maxNumber = int.MinValue;
            int sumOfAllNumbers = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sumOfAllNumbers += currentNumber;
                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;
                }
            }
            int sumOfAllNumbersWhitoutMaxNumner = sumOfAllNumbers - maxNumber;
            if (sumOfAllNumbersWhitoutMaxNumner == maxNumber)
            {
                Console.WriteLine("Yes" + Environment.NewLine + $"Sum = {maxNumber}");
            }
            else
            {
                int difference = Math.Abs(sumOfAllNumbersWhitoutMaxNumner - maxNumber);
                Console.WriteLine("No" + Environment.NewLine + $"Diff = {difference}");
            }
        }
    }
}
