using System;
using System.Linq;

namespace P04_Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var lake = new Froggy(input);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
