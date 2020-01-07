using System;
using System.Linq;

namespace Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            if (arr.Length == 1)
            {
                Console.WriteLine(arr[0]);
                return;
            }
            else
            {
                while (arr.Length != 1)
                {
                    int[] condensed = new int[arr.Length - 1];
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        condensed[i] = arr[i] + arr[i + 1];

                    }

                    arr = condensed;
                }

                Console.WriteLine(arr[0]);
            }
        }
    }
}
