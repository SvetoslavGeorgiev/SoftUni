using System;

namespace _07_Concat_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstName = Console.ReadLine();
            var SecondName = Console.ReadLine();
            var delimiter = Console.ReadLine();

            Console.WriteLine($"{firstName}{delimiter}{SecondName}");
        }
    }
}
