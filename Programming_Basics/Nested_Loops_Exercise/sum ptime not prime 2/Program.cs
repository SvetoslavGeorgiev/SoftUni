using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int sumPrime = 0;
            int sumNonPrime = 0;

            while (command != "stop")
            {
                int num = int.Parse(command);
                int counterPrimeNumber = 0;
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    command = Console.ReadLine();
                    continue;
                }
                for (int i = 1; i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        counterPrimeNumber++;
                    }
                }

                if (counterPrimeNumber == 2)
                {
                    sumPrime += num;
                }
                else
                {
                    sumNonPrime += num;
                }
                command = Console.ReadLine();

            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}