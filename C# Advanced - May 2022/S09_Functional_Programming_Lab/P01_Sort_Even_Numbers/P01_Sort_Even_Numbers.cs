using System;
using System.Linq;

namespace P01_Sort_Even_Numbers
{
    public class P01_Sort_Even_Numbers
    {
        static void Main()
        {

            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList();

            
            Console.WriteLine(string.Join(", ", input));
        }
    }
}
