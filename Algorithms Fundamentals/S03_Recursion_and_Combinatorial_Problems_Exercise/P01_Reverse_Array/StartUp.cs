namespace P01_Reverse_Array
{
    using System;
    using System.Linq;

    internal class StartUp
    {

        public static string[] arr;

        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split();


            ReverseArray(0);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void ReverseArray(int index)
        {

            if (index == arr.Length / 2)
            {
                return;
            }

            var temp = arr[index];
            arr[index] = arr[arr.Length - 1 - index];
            arr[arr.Length - 1 - index] = temp;

            ReverseArray(index + 1);

        }
    }
}