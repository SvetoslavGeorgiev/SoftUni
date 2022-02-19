using System;

namespace _03_Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            
            if (n == 1 || n == 2)
            {
                Console.WriteLine(1);
                return;
            }
            var fibonacciArr = new long[n];
            fibonacciArr[0] = 1;
            fibonacciArr[1] = 1;
            
            for (int i = 2; i < n; i++)
            {
                fibonacciArr[i] = fibonacciArr[i - 1] + fibonacciArr[i - 2];
            }

            Console.WriteLine(fibonacciArr[n - 1]);
        }
    }
}
