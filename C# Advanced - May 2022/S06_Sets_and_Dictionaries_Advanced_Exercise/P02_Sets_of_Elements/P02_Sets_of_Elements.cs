using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Sets_of_Elements
{
    class P02_Sets_of_Elements
    {
        static void Main()
        {
            int[] set = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            var nSet = new HashSet<int>();

            for (int i = 0; i < set[0]; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());

                firstSet.Add(currentNumber);
            }
            for (int i = 0; i < set[1]; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());

                secondSet.Add(currentNumber);
            }



            if (firstSet.Count >= secondSet.Count)
            {
                foreach (var number in secondSet)
                {
                    if (firstSet.Contains(number))
                    {
                        nSet.Add(number);
                    }
                }
            }
            else
            {
                foreach (var number in firstSet)
                {
                    if (secondSet.Contains(number))
                    {
                        nSet.Add(number);
                    }
                }
            }


            foreach (var number in nSet)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
