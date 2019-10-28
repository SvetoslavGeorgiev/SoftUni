using System;

namespace Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
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
