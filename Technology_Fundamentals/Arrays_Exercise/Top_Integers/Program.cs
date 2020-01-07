using System;
using System.Linq;

namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            //this one it's working as 
            //well but judge give me only 60/100. 



            //int[] arr = Console.ReadLine()
            //    .Split()
            //    .Select(int.Parse)
            //    .ToArray();
            //for (int i = 0; i <= arr.Length - 1; i++)
            //{
            //    for (int k = 0; k <= arr.Length - 1; k++)
            //    {
            //        if (k == arr.Length - 1 && arr[i] > arr[k])
            //        {
            //            Console.Write($"{arr[i]} ");
            //        }
            //        if (i == arr.Length - 1)
            //        {
            //            Console.Write(arr[i]);
            //            return;
            //        }
            //    }
            //}
            long[] inputArr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            for (long i = 0; i < inputArr.Length; i++)
            {
                bool isItBigger = true;
                for (long j = i + 1; j < inputArr.Length; j++)
                {
                    if (inputArr[i] <= inputArr[j])
                    {
                        isItBigger = false;
                    }
                }

                if (isItBigger)
                {
                    Console.Write(inputArr[i] + " ");
                }
            }
        }
    }
}
