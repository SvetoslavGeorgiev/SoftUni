using System;

namespace Multiplication_Table_2_0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int startNumber = int.Parse(Console.ReadLine());
            int product = 0;

            for (int i = startNumber; i <= 10; i++)
            {
                product = number * i;
                Console.WriteLine($"{number} X {i} = {product}");
            }
            if (startNumber > 10)
            {
                product = number * startNumber;
                Console.WriteLine($"{number} X {startNumber} = {product}");
            }
        }
    }
}
