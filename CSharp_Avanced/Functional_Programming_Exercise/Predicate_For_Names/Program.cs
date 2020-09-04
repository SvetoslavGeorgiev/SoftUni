using System;
using System.Linq;

namespace Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
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
