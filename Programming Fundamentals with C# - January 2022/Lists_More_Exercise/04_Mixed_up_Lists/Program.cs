using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var mixedList = new List<int>();


            if (firstList.Count > secondList.Count)
            {
                var firstConditionNumber = firstList[secondList.Count];
                firstList.RemoveAt(secondList.Count);
                var secondConditionNumber = firstList[secondList.Count];
                firstList.RemoveAt(secondList.Count);

                for (int i = 0; i < firstList.Count; i++)
                {
                    mixedList.Add(firstList[i]);
                    mixedList.Add(secondList[secondList.Count - 1 - i]);
                }
                var to = Math.Max(firstConditionNumber, secondConditionNumber);
                var from = Math.Min(firstConditionNumber, secondConditionNumber);
                var output = mixedList.Where(x => x > from && x < to).ToList();
                output.Sort();

                Console.WriteLine(string.Join(" ", output));

            }
            else
            {
                var firstConditionNumber = secondList[0];
                secondList.RemoveAt(0);
                var secondConditionNumber = secondList[0];
                secondList.RemoveAt(0);

                for (int i = 0; i < firstList.Count; i++)
                {
                    mixedList.Add(firstList[i]);
                    mixedList.Add(secondList[secondList.Count - 1 - i]);
                }
                var to = Math.Max(firstConditionNumber, secondConditionNumber);
                var from = Math.Min(firstConditionNumber, secondConditionNumber);
                var output = mixedList.Where(x => x > from && x < to).ToList();
                output.Sort();

                Console.WriteLine(string.Join(" ", output));
            }
        }
    }
}
