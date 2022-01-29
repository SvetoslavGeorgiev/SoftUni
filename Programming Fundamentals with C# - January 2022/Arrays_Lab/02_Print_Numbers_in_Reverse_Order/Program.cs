using System;
using System.Collections.Generic;

namespace _02_Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //same results with using list!!!


            //var number = int.Parse(Console.ReadLine());

            //List<int> listOfNumbers = new List<int>();

            //for (int i = 0; i < number; i++)
            //{
            //    var currentNumber = int.Parse(Console.ReadLine());

            //    listOfNumbers.Add(currentNumber);
            //}

            //listOfNumbers.Reverse();

            //Console.Write(string.Join(" ", listOfNumbers));


            int numbers = int.Parse(Console.ReadLine());

            int[] arrays = new int[numbers];

            for (int i = 0; i < numbers; i++)
            {
                arrays[i] = int.Parse(Console.ReadLine());
            }
            for (int i = arrays.Length - 1; i >= 0; i--)
            {

                Console.Write($"{arrays[i]} ");
            }

        }
    }
}