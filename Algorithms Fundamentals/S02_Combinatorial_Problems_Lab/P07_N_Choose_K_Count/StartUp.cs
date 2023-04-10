namespace P07_N_Choose_K_Count
{
    using System;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var top = GetFactorial(n);
            var bottom = GetFactorial(k) * GetFactorial(n - k);

            Console.WriteLine(top / bottom);
        }

        private static double GetFactorial(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * GetFactorial(number - 1);
        }

    }
}