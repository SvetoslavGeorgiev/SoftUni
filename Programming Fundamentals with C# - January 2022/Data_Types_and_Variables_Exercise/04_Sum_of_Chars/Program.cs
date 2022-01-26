using System;

namespace _04_Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var numberOfInputs = int.Parse(Console.ReadLine());

            var sumOfTheChars = 0;
            for (int i = 0; i < numberOfInputs; i++)
            {
                var input = char.Parse(Console.ReadLine());

                sumOfTheChars += input;

            }

            Console.WriteLine($"The sum equals: {sumOfTheChars}");
        }
    }
}
