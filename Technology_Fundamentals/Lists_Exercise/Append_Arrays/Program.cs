using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> bigList = Console.ReadLine().Split('|').ToList();

            List<int> newList = new List<int>();

            for (int i = bigList.Count - 1; i >= 0; i--)
            {
                string temp = bigList[i];

                List<int> temp1 = temp.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                for (int k = 0; k < temp1.Count; k++)
                {
                    newList.Add(temp1[k]);
                }
            }
            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
