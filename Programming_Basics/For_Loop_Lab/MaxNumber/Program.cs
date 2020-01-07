using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int nextNumber = int.Parse(Console.ReadLine());

                if (nextNumber > number)
                {
                    number = nextNumber;
                }
            }
            Console.WriteLine(number);
        }
    }
}
