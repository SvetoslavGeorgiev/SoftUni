using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine().Split().Select(int.Parse).ToList();

            var list = new List<int>();

            var condition = Console.ReadLine();

            Predicate<int> pr = Cheker(condition);

            for (int i = range[0]; i <= range[1]; i++)
            {
                if (pr(i))
                {
                    list.Add(i);
                }
            }
            Console.Write(string.Join(" ", list));
        }

        private static Predicate<int> Cheker(string condition)
        {
            switch (condition)
            {
                case "odd":
                    return x => x % 2 != 0;
                case "even":
                    return x => x % 2 == 0;
                default:
                    return null;
            }
        }
    }
}
