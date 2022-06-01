using System;
using System.Linq;

namespace P07_Predicate_For_Names
{
    public class P07_Predicate_For_Names
    {
        static void Main()
        {
            var requiredLength = int.Parse(Console.ReadLine());

            Func<string, bool> maxLenght = MaxLennght(requiredLength);

            Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(maxLenght)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private static Func<string, bool> MaxLennght(int requiredLength)
        {
            return x => x.Length <= requiredLength;
        }
    }
}
