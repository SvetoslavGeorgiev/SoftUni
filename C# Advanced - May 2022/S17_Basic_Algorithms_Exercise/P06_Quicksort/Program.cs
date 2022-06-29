using System;
using System.Linq;

namespace P06_Quicksort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Quick.Sort<int>(arr);

            Console.WriteLine(string.Join(" ", arr));


        }
    }


    public class Quick
    {

        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {

            Shuffle(arr);
            Sort(arr, 0, arr.Length - 1);


        }

        private static void Sort<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            if (lo >= hi)
            {
                return;
            }

            var part = Partition(arr, lo, hi);
            Sort(arr, lo, part - 1);
            Sort(arr, part + 1, hi);

        }

        private static int Partition<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            if (lo >= hi)
            {
                return lo;
            }

            var i = lo;
            var j = hi + 1;

            while (true)
            {

                while (IsLess(arr[++i], arr[lo]))
                {
                    if (i == hi)
                    {
                        break;
                    }
                }

                while (IsLess(arr[lo], arr[--j]))
                {
                    if (j == lo)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }

                Swap(arr, i, j);

            }

            Swap(arr, lo, j);
            return j;
        }

        private static void Swap<T>(T[] arr, int i, int j) where T : IComparable<T>
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static void Shuffle<T>(T[] arr) where T : IComparable<T>
        {
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                var r = i + random.Next(0, arr.Length - i);
                Swap(arr, i, r);
            }
        }


        private static bool IsLess<T>(T item1, T item2) where T : IComparable<T>
        {
            return item1.CompareTo(item2) < 0;
        }
    }
}
