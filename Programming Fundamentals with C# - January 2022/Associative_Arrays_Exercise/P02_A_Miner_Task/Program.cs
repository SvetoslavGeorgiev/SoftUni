using System;
using System.Collections.Generic;

namespace P02_A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;

            var resources = new Dictionary<string, int>();

            var counter = 0;

            var currentKey = string.Empty;
            while ((command = Console.ReadLine()) != "stop")
            {
                counter++;
                if (counter % 2 != 0)
                {
                    currentKey = command;
                }
                else
                {
                    if (!resources.ContainsKey(currentKey))
                    {
                        resources.Add(currentKey, int.Parse(command));
                    }
                    else
                    {
                        resources[currentKey] += int.Parse(command);
                    }
                }
            }

            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
