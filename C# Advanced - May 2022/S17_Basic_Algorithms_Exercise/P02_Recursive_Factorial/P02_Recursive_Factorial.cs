using System;

namespace P02_Recursive_Factorial
{
    public class P02_Recursive_Factorial
    {
        static void Main()
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
