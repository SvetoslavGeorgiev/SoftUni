using System;

namespace EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int preveousSum = 0;
            int currSum = 0;
            int currDiff = 0;
            int maxDiff = 0;

            for (int i = 1; i <= n; i++)
            {
                preveousSum = currSum;
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                currSum = first + second;

                currDiff = Math.Abs(currSum - preveousSum);

                if (preveousSum != currSum && i >= 2)
                {
                    maxDiff = currDiff;
                }
                if (currDiff > maxDiff && i >= 2)
                {
                    maxDiff = currDiff;
                }
            }

            if (maxDiff != 0)
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
            else
            {
                Console.WriteLine($"Yes, value={currSum}");
            }
        }
    }
}
