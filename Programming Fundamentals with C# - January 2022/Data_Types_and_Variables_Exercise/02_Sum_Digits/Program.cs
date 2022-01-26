using System;

namespace _02_Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine();

            var sumOfTheDigets = 0;

            for (int i = 0; i < number.Length; i++)
            {
                var num = int.Parse(number[i].ToString());

                sumOfTheDigets += (int)num;
            }

            Console.WriteLine(sumOfTheDigets);
        }
    }
}
