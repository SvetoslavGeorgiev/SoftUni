using System;
using System.Linq;

namespace Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();
            int rotations = int.Parse(Console.ReadLine());


            for (int i = 1; i <= rotations; i++)
            {
                string temp = input[0];
                for (int k = 0; k <= input.Length - 1; k++)
                {
                    if (k != 0)
                    {
                        input[k - 1] = input[k];
                    }
                }
                input[input.Length - 1] = temp;
            }
            Console.WriteLine(string.Join(" ", input));
        }
        //static void Main(string[] args)
        //{
        //    string[] input = Console.ReadLine()
        //        .Split()
        //        .ToArray();
        //    int rotations = int.Parse(Console.ReadLine());


        //    for (int i = 1; i <= rotations; i++)
        //    {
        //        for (int k = 0; k <= input.Length - 1; k++)
        //        {
        //            if (k == 0)
        //            {
        //                input[input.Length - 1] = input[0];
        //            }
        //            else
        //            {
        //                input[k - 1] = input[k];
        //            }
        //        }
        //    }
        //    Console.WriteLine(string.Join(" ", input));
        //}
    }
}
