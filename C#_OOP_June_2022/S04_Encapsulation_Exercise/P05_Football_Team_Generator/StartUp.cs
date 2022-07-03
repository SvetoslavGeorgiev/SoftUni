using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Football_Team_Generator
{
    public class StartUp
    {
        static void Main()
        {

            var teams = new Dictionary<string, Team>();
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
                if (tokens.Contains("Team"))
                {
                    var team = new Team(tokens[1]);
                    teams.Add(tokens[1], team);
                }
                else if (tokens.Contains("Add"))
                {
                    if (!teams.ContainsKey(tokens[1]))
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                        continue;
                    }
                    var player = new Player(tokens[2],
                        int.Parse(tokens[3]),
                        int.Parse(tokens[4]),
                        int.Parse(tokens[5]),
                        int.Parse(tokens[6]),
                        int.Parse(tokens[7]));
                    if (player.ValidPlayer)
                    {
                        teams[tokens[1]].AddPlayer(player);
                    }
                    
                }
                else if (tokens.Contains("Remove"))
                {
                    teams[tokens[1]].RemovePlayer(tokens[2]);
                }
                else if (tokens.Contains("Rating"))
                {
                    if (!teams.ContainsKey(tokens[1]))
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                        continue;
                    }
                    Console.WriteLine($"{tokens[1]} - {teams[tokens[1]].Rating}");
                }
            }

        }
    }
}
