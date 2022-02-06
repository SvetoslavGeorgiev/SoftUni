using System;

namespace _06_Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            string output = GetMiddleCharacters(input);
            Console.WriteLine(output);
        }

        private static string GetMiddleCharacters(string input)
        {
            var result = string.Empty;

            if (input.Length % 2 == 0)
            {
                result = input[(input.Length / 2) - 1].ToString() + input[input.Length / 2].ToString();
            }
            else
            {
                result = input[input.Length / 2].ToString();
            }
            return result;
        }
    }
}
