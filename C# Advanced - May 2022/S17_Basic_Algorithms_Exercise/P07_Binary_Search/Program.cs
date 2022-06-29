using System;
using System.Linq;

namespace P07_Binary_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var key = int.Parse(Console.ReadLine());

            
            Console.WriteLine(BinarySearch.IndexOf(arr, key));
            
        }


        public class BinarySearch
        {
            public static int IndexOf(int[] arr, int key)
            {
                var lo = 0;
                var hi = arr.Length - 1;

                while (lo <= hi)
                {

                    var mid = lo + (hi - lo) / 2;

                    if (key < arr[mid])
                    {
                        hi = mid - 1;
                    }
                    else if (key > arr[mid])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }

                return -1;
            }
        }
    }
}
