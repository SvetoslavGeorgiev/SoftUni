namespace P04_Recursive_Factorial
{
    using System;

    internal class StartUp
    {
        static void Main(string[] args)
        {

            var number = int.Parse(Console.ReadLine());

            long sum = SumArray(number);

            Console.WriteLine(sum);

        }

        private static long SumArray(int startIndex)
        {

            if (startIndex == 1)
            {
                return startIndex;
            }

            return startIndex * SumArray(startIndex - 1);

        }
    }
}