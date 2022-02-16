using System;

namespace _04_Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            PrintTribonnaci(num);

        }

        private static void PrintTribonnaci(int num)
        {
            var arr = new int[num];

            for (int i = 1; i <= num; i++)
            {
                if (i == 1)
                {
                    Console.Write($"{1} ");
                    arr[i - 1] = 1;
                }
                else if (i == 2)
                {
                    Console.Write($"{1} ");
                    arr[i - 1] = 1;
                }
                else if (i == 3)
                {
                    Console.Write($"{2} ");
                    arr[i - 1] = 2;
                }
                else
                {
                    var sum = arr[i - 4] + arr[i - 3] + arr[i - 2];
                    arr[i - 1] = sum;
                    Console.Write($"{arr[i - 1]} ");
                }
            }
        }
    }
}
