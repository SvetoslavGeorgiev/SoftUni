using System;
using System.Linq;

namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var numberToDivideWith = int.Parse(Console.ReadLine());


            var reversedListv = numbers.Where(x => x % numberToDivideWith != 0).Reverse();


            Console.WriteLine(string.Join(" ", reversedListv));



        }
    }
}
