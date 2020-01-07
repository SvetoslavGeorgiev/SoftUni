using System;
using System.Diagnostics;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            string number = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int curentDigitToNum = int.Parse(number[i].ToString());
                sum += curentDigitToNum;
            }
            Console.WriteLine(sum);
            //you can use this type of writig(logic) as well!!!

            //int number = int.Parse(Console.ReadLine());

            //int sumOdDigit = 0;
            //int lastDigit;

            //while (number != 0)
            //{
            //    lastDigit = number % 10;
            //    sumOdDigit += lastDigit;
            //    number /= 10;
            //}
            //Console.WriteLine(sumOdDigit);
            Console.WriteLine(sw.Elapsed);
        }
    }
}
