using System;

namespace _10._Multiplication_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var integer = int.Parse(Console.ReadLine());
            var sum = 0;

            for (int i = 1; i <= 10; i++)
            {
                sum = integer * i;
                Console.WriteLine($"{integer} X {i} = {sum}");
            }
        }
    }
}
