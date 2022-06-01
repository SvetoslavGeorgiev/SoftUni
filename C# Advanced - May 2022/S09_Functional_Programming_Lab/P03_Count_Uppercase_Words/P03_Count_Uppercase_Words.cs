using System;
using System.Linq;

namespace P03_Count_Uppercase_Words
{
    public class P03_Count_Uppercase_Words
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x[0] == x.ToUpper()[0])
                .ToList();


            Console.WriteLine(string.Join("\n", input));
        }
    }
}
