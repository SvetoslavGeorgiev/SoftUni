using System;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int sum2 = 0;

            for (int i = 0; i < n; i++)
            {
                int nextNumber = int.Parse(Console.ReadLine());
                sum += nextNumber;
            }
            for (int i = 0; i < n; i++)
            {
                int nextNumber = int.Parse(Console.ReadLine());
                sum2 += nextNumber;
            }
            if (sum == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum}");
            }
            else
            {
                int diference = Math.Abs(sum - sum2);
                Console.WriteLine($"No, diff = {diference}");
            }
        }
    }
}
