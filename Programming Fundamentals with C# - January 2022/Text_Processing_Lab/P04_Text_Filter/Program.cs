using System;

namespace P04_Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");

            string text = Console.ReadLine();

            foreach (var words in bannedWords)
            {
                text = text.Replace(words, new string('*', words.Length));
            }

            Console.WriteLine(text);
        }
    }
}
