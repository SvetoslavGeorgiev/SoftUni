using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x[0] == x.ToUpper()[0])
                .ToList();


            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}
