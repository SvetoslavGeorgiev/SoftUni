using System;

namespace Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double result = 0;

            for (int i = 0; i <= n; i += 2)
            {
                result = Math.Pow(2, i);
                Console.WriteLine(result);
            }
        }
    }
}
