using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Filter
{
    class Program
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
