using System;
using System.Collections.Generic;

namespace P05_SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfCommands = int.Parse(Console.ReadLine());

            var carPark = new Dictionary<string, string>();

            for (int i = 1; i <= numberOfCommands; i++)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "register")
                {
                    if (carPark.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {command[2]}");
                    }
                    else
                    {
                        carPark.Add(command[1], command[2]);
                        Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                    }
                }
                else
                {
                    if (!carPark.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: user {command[1]} not found");
                    }
                    else
                    {
                        carPark.Remove(command[1]);
                        Console.WriteLine($"{command[1]} unregistered successfully");
                    }
                }
            }

            foreach (var user in carPark)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
