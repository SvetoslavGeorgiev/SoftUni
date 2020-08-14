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

            // SECOND VARIANT OF THE SOLUTION
            //Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Where(x => char.IsUpper[x[0]))
            //    .ToList()
            //    .ForEach(Console.WriteLine);
        }
    }
}
