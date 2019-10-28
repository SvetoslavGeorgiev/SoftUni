using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                int nextNumber = int.Parse(Console.ReadLine());

                if (nextNumber < number)
                {
                    number = nextNumber;
                }
            }
            Console.WriteLine(number);
        }
    }
}
