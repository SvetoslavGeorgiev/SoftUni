using System;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int currentCount = 1;
            double sum = 0;

            while (currentCount <= count)
            {
                double currentNumber = double.Parse(Console.ReadLine());
                if (currentNumber < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                sum += currentNumber;
                Console.WriteLine($"Increase: {currentNumber:F2}");
                currentCount++;
            }
            Console.WriteLine($"Total: {sum:F2}");
        }
    }
}
