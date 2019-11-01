using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem07AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            while (command != "3:1")
            {
                string[] temp = command.Split();

                int startIndex = int.Parse(temp[1]);
                int start = Math.Max(startIndex, 0);
                int endIndex = int.Parse(temp[2]);
                int end = Math.Min(endIndex, list.Count);
                if (end == list.Count)
                {
                    end = end - 1;
                }
                int index = int.Parse(temp[1]);
                int partitions = int.Parse(temp[2]);

                if (temp[0] == "merge")
                {
                    List<string> merge = new List<string>();
                    for (int i = start; i <= end; i++)
                    {
                        merge.Add(list[i]);

                    }
                    if (start < end)
                    {
                        int count = end - start + 1;
                        list.RemoveRange(start, count);
                        string add = string.Join("", merge);

                        list.Insert(start, add);
                    }
                }
                else
                {
                    string stringForDevition = list[index];

                    list.RemoveAt(index);
                    var stringToAdd = new List<string>();
                    int partitionLength = stringForDevition.Length / partitions;
                    int remainder = stringForDevition.Length % partitions;

                    string token = string.Empty;
                    int count = 0;

                    for (int i = 0; i < stringForDevition.Length; i++)
                    {
                        token += stringForDevition[i];
                        if (token.Length == partitionLength)
                        {
                            stringToAdd.AddRange(token.Split().ToList());
                            token = string.Empty;
                            count++;
                            if (count == partitions - 1)
                            {
                                partitionLength += remainder;
                            }
                        }
                    }
                    list.InsertRange(index, stringToAdd);
                }
                command = Console.ReadLine();
            }   
            Console.WriteLine(string.Join(" ", list));
        }
    }
}