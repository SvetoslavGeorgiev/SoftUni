using System;

namespace Number_in_Range_1__100
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            while (a < 1 || a > 100)
            {
                Console.WriteLine("Ivalid number");

                a = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The number is {a}");
        }
    }
}
