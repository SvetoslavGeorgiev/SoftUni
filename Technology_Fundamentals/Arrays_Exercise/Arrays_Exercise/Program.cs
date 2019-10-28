using System;

namespace Train

{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] nums = new int[wagons];
            int sum = 0;

            for (int i = 0; i <= wagons-1; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
                sum += nums[i];
            }

            Console.WriteLine(string.Join(" ", nums));
            Console.WriteLine(sum);
        }
    }
}
