namespace P07_Recursive_Fibonacci
{
    using System;
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(n));
        }


        private static int GetFibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}