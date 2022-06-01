using System;
using System.Linq;

namespace P06_Reverse_And_Exclude
{
    public class P06_Reverse_And_Exclude
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var numberToDivideWith = int.Parse(Console.ReadLine());


            var reversedListv = numbers.Where(x => x % numberToDivideWith != 0).Reverse();


            Console.WriteLine(string.Join(" ", reversedListv));
        }
    }
}
