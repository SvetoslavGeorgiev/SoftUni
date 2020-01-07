using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            var usersDict = new Dictionary<string, List<string>>();

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                if (command.Contains("|"))
                {
                    var list1 = command.Split(" | ").ToList();

                    var user = list1[1];
                    var side = list1[0];

                    if (!usersDict.ContainsKey(side))
                    {
                        if (!usersDict.Any(x => x.Value.Contains(user)))
                        {
                            usersDict.Add(side, new List<string>());
                            usersDict[side].Add(user);
                        }
                    }
                    else
                    {
                        if (!usersDict.Any(x => x.Value.Contains(user)))
                        {
                            usersDict[side].Add(user);
                        }
                    }
                }
                else
                {
                    var list1 = command.Split(" -> ").ToList();

                    var user = list1[0];
                    var side = list1[1];

                    foreach (var check in usersDict)
                    {
                        if (check.Value.Contains(user))
                        {
                            check.Value.Remove(user);
                        }
                    }
                    if (!usersDict.ContainsKey(side))
                    {
                        usersDict.Add(side, new List<string>());
                        usersDict[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                    else
                    {
                        usersDict[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                }
            }
            foreach (var kvp in usersDict.Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                foreach (var user in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }

        }
    }
}
