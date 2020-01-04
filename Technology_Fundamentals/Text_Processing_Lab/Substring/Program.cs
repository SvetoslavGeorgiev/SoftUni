using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            var input = Console.ReadLine();

            var length = word.Length;

            while (input.Contains(word, StringComparison.CurrentCultureIgnoreCase))
            {
                var index = input.IndexOf(word, StringComparison.CurrentCultureIgnoreCase);

                input = input.Remove(index, length);
            }

            Console.WriteLine(input);
        }
    }
}
