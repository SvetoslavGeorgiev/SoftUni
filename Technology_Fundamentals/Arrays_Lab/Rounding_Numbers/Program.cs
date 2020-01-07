using System;

namespace Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();
            string[] valuesAsStrings = values.Split();

            double[] numbers = new double[valuesAsStrings.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = double.Parse(valuesAsStrings[i]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]} => {Math.Round(numbers[i], MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
