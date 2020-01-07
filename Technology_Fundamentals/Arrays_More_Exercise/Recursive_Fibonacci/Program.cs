using System;

namespace Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] fib = new double[50];

            for (int i = 0; i < fib.Length; i++)
            {
                if (i == 0 || i == 1)
                {
                    fib[i] = 1;
                }
                else
                {
                    fib[i] = fib[i - 1] + fib[i - 2];
                }
            }

            int fibNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(fib[fibNumber - 1]);
        }
    }
}
