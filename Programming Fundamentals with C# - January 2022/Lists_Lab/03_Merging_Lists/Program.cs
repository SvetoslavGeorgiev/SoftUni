using System;
using System.Linq;
using System.Collections.Generic;

namespace merging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToList();
            List<int> numbers2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();



            List<int> mergedLists = new List<int>();

            if (numbers1.Count == numbers2.Count)
            {
                for (int i = 0; i <= numbers1.Count - 1; i++)
                {
                    mergedLists.Add(numbers1[i]);
                    mergedLists.Add(numbers2[i]);
                }
            }
            else if (numbers2.Count > numbers1.Count)
            {
                for (int i = 0; i <= numbers1.Count - 1; i++)
                {
                    mergedLists.Add(numbers1[i]);
                    mergedLists.Add(numbers2[i]);
                }
                for (int i = numbers1.Count; i <= numbers2.Count - 1; i++)
                {
                    mergedLists.Add(numbers2[i]);
                }
            }
            else
            {
                for (int i = 0; i <= numbers2.Count - 1; i++)
                {
                    mergedLists.Add(numbers1[i]);
                    mergedLists.Add(numbers2[i]);
                }
                for (int i = numbers2.Count; i <= numbers1.Count - 1; i++)
                {
                    mergedLists.Add(numbers1[i]);
                }
            }

            Console.WriteLine(string.Join(" ", mergedLists));
        }
    }
}
