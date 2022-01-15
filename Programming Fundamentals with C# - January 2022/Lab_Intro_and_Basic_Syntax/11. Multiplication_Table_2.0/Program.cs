using System;

namespace _11._Multiplication_Table_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var integer = int.Parse(Console.ReadLine());

            var times = int.Parse(Console.ReadLine());

            var sum = 0;

            if (times > 10)
            {
                sum = integer * times;
                Console.WriteLine($"{integer} X {times} = {sum}");
            }

            for (int i = times; i <= 10; i++)
            {
                sum = integer * i;
                Console.WriteLine($"{integer} X {i} = {sum}");
            }
        }
    }
}