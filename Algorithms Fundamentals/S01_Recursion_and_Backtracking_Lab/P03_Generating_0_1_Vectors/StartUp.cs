namespace P03_Generating_0_1_Vectors
{
    using System;

    internal class StartUp
    {
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            Gen01(arr, 0);

        }

        private static void Gen01(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                arr[index] = i;
                Gen01(arr, index + 1);
            }
        }
    }
}