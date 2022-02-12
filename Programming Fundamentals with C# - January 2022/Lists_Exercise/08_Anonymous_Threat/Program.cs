using System;
using System.Linq;
using System.Collections.Generic;

namespace _08_Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "3:1")
            {
                var currendCommand = command.Split();
                var action = currendCommand[0];
                if (action == "merge")
                {
                    Merge(currendCommand, input);
                }
                else if (action == "divide")
                {
                    Devide(currendCommand, input);
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }

        private static void Devide(string[] currendCommand, List<string> input)
        {
            
            var index = int.Parse(currendCommand[1]);
            var partition = input[index];
            var partitions = int.Parse(currendCommand[2]);
            if (partitions == 0)
            {
                return;
            }
            var currentPartition = string.Empty;
            
            var lenghtOfThePartition = partition.Length / partitions;
            input.RemoveAt(index);

            var leftOvers = partition.Length % partitions;

            for (int i = 0; i <= partition.Length - 1; i++)
            {
                if (i == partition.Length - 1 - leftOvers)
                {
                    lenghtOfThePartition += leftOvers;
                }
                currentPartition += partition[i];
                if (currentPartition.Length == lenghtOfThePartition)
                {
                    input.Insert(index, currentPartition);
                    index++;
                    currentPartition = string.Empty;
                }
            }
        }

        private static void Merge(string[] currendCommand, List<string> input)
        {
            var startIndex = Math.Max(0, int.Parse(currendCommand[1]));
            var endIndex = Math.Min(input.Count - 1, int.Parse(currendCommand[2]));
            var tempString = string.Empty;
            var isMerget = false;
            for (int i = startIndex; i <= endIndex; i++)
            {
                tempString += input[i];
                input.RemoveAt(i);
                i--;
                endIndex--;
                isMerget = true;
            }
            if (isMerget)
            {
                input.Insert(startIndex, tempString);
            }
        }
    }
}