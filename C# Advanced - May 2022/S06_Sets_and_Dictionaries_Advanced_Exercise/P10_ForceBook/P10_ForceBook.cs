using System;
using System.Collections.Generic;
using System.Linq;

namespace P10_ForceBook
{
    class P10_ForceBook
    {
        static void Main()
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

                    if (!usersDict.Any(x => x.Value.Contains(user)))
                    {
                        if (!usersDict.ContainsKey(side))
                        {
                            usersDict.Add(side, new List<string>());
                        }
                        usersDict[side].Add(user);
                    }
                }
                else
                {
                    var list1 = command.Split(" -> ").ToList();

                    var user = list1[0];
                    var side = list1[1];

                    foreach (var kvp in usersDict)
                    {
                        if (kvp.Value.Contains(user))
                        {
                            kvp.Value.Remove(user);
                        }
                    }

                    if (!usersDict.ContainsKey(side))
                    {
                        usersDict.Add(side, new List<string>());
                    }
                    usersDict[side].Add(user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }
            foreach (var kvp in usersDict.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
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
