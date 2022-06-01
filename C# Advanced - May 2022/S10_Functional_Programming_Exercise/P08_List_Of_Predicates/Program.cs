using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var endNumber = int.Parse(Console.ReadLine());

            var conditions = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            var result = new List<int>();

            for (int i = 1; i <= endNumber; i++)
            {

                var isDivisible = true;

                foreach (var con in conditions)
                {
                    Predicate<int> pr = x => i % x == 0;

                    if (!pr(con))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
