using System;

namespace P03_Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();

            var input = Console.ReadLine();

            var length = word.Length;

            while (input.Contains(word))
            {
                var index = input.IndexOf(word);

                input = input.Remove(index, length);
            }

            Console.WriteLine(input);
        }
    }
}
