using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Longest_Increasing_Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var solutionsOFEachPreviosNumbers = new int[arr.Length];
            var maxSolutions = 0;
            var previusBestSolutionIndex = new int[arr.Length];
            var maxSolutionIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                var solution = 1;
                var previusBestIndex = -1;
                
                for (int j = 0; j < i; j++)
                {
                    var prevSolutions = solutionsOFEachPreviosNumbers[j];
                    if (arr[i] > arr[j] && solution <= prevSolutions)
                    {
                        solution = prevSolutions + 1;
                        previusBestIndex = j;
                    }
                }
                previusBestSolutionIndex[i] = previusBestIndex;
                solutionsOFEachPreviosNumbers[i] = solution;
                if (maxSolutions < solution)
                {
                    maxSolutions = solution;
                    maxSolutionIndex = i;
                }
            }

            var index = maxSolutionIndex;

            var result = new List<int>();

            while (index != -1)
            {
                var num = arr[index];
                result.Add(num);
                index = previusBestSolutionIndex[index];
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
