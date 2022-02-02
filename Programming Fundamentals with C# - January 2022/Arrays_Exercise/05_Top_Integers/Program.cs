using System;
using System.Linq;

namespace _05_Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                var currentNumber = arr[i];
                var isItBigger = true;
                for (int k = i + 1; k < arr.Length; k++)
                {
                    if (currentNumber <= arr[k])
                    {
                        isItBigger = false;
                    }
                }
                if (isItBigger)
                {
                    Console.Write($"{arr[i]} ");
                }
            }
        }
    }
}