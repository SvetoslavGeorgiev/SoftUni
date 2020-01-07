using System;
using System.Linq;

namespace Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] arrFirst = new int[arr.Length / 4];
            int[] arrMid = new int[arr.Length / 2];
            int[] arrLast = new int[arr.Length / 4];

            

            for (int i = 0; i < arrFirst.Length; i++)
            {
                arrFirst[i] = arr[i];
            }
            for (int i = arrFirst.Length; i < arr.Length - arrLast.Length; i++)
            {
                arrMid[i - arrFirst.Length] = arr[i];
            }
            for (int i = arrFirst.Length + arrMid.Length; i < arr.Length; i++)
            {
                arrLast[i - arrFirst.Length - arrMid.Length] = arr[i];
            }

            Array.Reverse(arrFirst);
            Array.Reverse(arrLast);

            for (int i = 0; i < arrFirst.Length; i++)
            {
                arrMid[i] = arrMid[i] + arrFirst[i];
            }
            for (int i = arrFirst.Length; i < arrMid.Length; i++)
            {
                arrMid[i] = arrMid[i] + arrLast[i - arrFirst.Length];
            }

            Console.WriteLine(string.Join(" ", arrMid));
        }
    }
}
