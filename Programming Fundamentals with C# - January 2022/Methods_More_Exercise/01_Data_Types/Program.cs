using System;

namespace _01_Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            
            if (input == "int")
            {
                var result = 0;
                var number = int.Parse(Console.ReadLine());
                result = number * 2;
                Console.WriteLine(result);
            }
            else if(input == "real")
            {
                var result = 0.00;
                var number = double.Parse(Console.ReadLine());
                result = number * 1.5;
                Console.WriteLine($"{result:F2}");
            }
            else
            {
                var str = Console.ReadLine();
                Console.WriteLine($"${str}$");
            }
        }
    }
}
