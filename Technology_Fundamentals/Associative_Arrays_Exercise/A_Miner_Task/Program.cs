using System;
using System.Collections.Generic;
using System.Linq;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;
            var resources = new Dictionary<string, int>();
            while ((command = Console.ReadLine()) != "stop")
            {
               var command2 = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(command))
                {
                    resources[command] += command2;
                }
                else
                {
                    resources.Add(command, command2);
                }
            }
            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
