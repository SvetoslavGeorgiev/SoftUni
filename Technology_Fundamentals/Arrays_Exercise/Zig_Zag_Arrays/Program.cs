using System;
using System.Linq;

namespace Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArrays = int.Parse(Console.ReadLine());

            string[] arr1 = new string[numberOfArrays];
            string[] arr2 = new string[numberOfArrays];

            for (int i = 1; i <= numberOfArrays; i++)
            {
                string[] currentArr = Console.ReadLine().Split().ToArray();

                if (i % 2 != 0)
                {
                    arr1[i - 1] = currentArr[0];
                    arr2[i - 1] = currentArr[1];
                }
                else
                {
                    arr1[i - 1] = currentArr[1];
                    arr2[i - 1] = currentArr[0];
                }
                
            }
            

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
