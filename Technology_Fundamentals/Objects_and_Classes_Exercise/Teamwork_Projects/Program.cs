using System;
using System.Collections.Generic;
using System.Linq;

namespace Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCreators = int.Parse(Console.ReadLine());

            TeamsCatalog teamCatalog = new TeamsCatalog();

            teamCatalog = GetAddedNewTeams(teamCatalog, numberOfCreators);


            //var list = teamCatalog.FirstCatalog.OrderByDescending(x => x.MembersNames.Count()).ToList();

            var orderedList = teamCatalog.FirstCatalog.OrderByDescending(x => x.MembersNames.Count).ThenBy(x => x.TeamName).ToList();
            //var orderedList = list.Where(x => x.MembersNames.Count == x.MembersNames.Count).OrderBy(x => x.TeamName).ToList();

            foreach (var teams in orderedList)
            {

                if (teams.MembersNames.Count > 0)
                {
                    Console.WriteLine(teams.TeamName);
                    Console.WriteLine($"- {teams.CreatorName}");
                    teams.MembersNames.Sort();
                    foreach (var item in teams.MembersNames)
                    {
                        Console.WriteLine($"-- {item}");
                    }
                }

            }
            Console.WriteLine("Teams to disband:");
            foreach (var teams in orderedList)
            {
                if (teams.MembersNames.Count <= 0)
                {
                    Console.WriteLine(teams.TeamName);
                }
            }

        }

        private static TeamsCatalog GetAddedNewTeams(TeamsCatalog teamCatalog, int numberOfCreators)
        {
            for (int i = 1; i <= numberOfCreators; i++)
            {
                List<string> team = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).ToList();

                Team newTeam = new Team(team[1], team[0]);

                if (teamCatalog.FirstCatalog.Any(x => x.TeamName == team[1]))
                {
                    Console.WriteLine($"Team {team[1]} was already created!");
                }
                else if (teamCatalog.FirstCatalog.Any(x => x.CreatorName == team[0]))
                {
                    Console.WriteLine($"{team[0]} cannot create another team!");
                }
                else
                {
                    teamCatalog.FirstCatalog.Add(newTeam);
                    Console.WriteLine($"Team {newTeam.TeamName} has been created by {newTeam.CreatorName}!");
                }
            }
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                List<string> temp = command.Split("->", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!teamCatalog.FirstCatalog.Any(x => x.TeamName == temp[1]))
                {
                    Console.WriteLine($"Team {temp[1]} does not exist!");
                }
                else if (teamCatalog.FirstCatalog.Any(x => x.CreatorName == temp[0])
                    || teamCatalog.FirstCatalog.Any(x => x.MembersNames.Contains(temp[0])))
                {
                    Console.WriteLine($"Member {temp[0]} cannot join team {temp[1]}!");
                }
                else
                {
                    foreach (var teams in teamCatalog.FirstCatalog)
                    {
                        if (teams.TeamName == temp[1])
                        {
                            //foreach (var item in teams.MembersNames)
                            //{
                            //    if (item == temp[0])
                            //    {
                            //        Console.WriteLine($"Member {temp[0]} cannot join team {temp[1]}!");
                            //        break;
                            //    }
                            //}
                            teams.MembersNames.Add(temp[0]);
                        }
                    }
                }
            }
            return teamCatalog;
        }
        class Team
        {

            public Team(string teamName, string creatorName)
            {
                TeamName = teamName;
                CreatorName = creatorName;
                MembersNames = new List<string>();
            }


            public string TeamName { get; set; }

            public string CreatorName { get; set; }

            public List<string> MembersNames { get; set; }

        }

        class TeamsCatalog
        {
            public TeamsCatalog()
            {
                FirstCatalog = new List<Team>();
            }
            public List<Team> FirstCatalog { get; set; }
        }
    }




}
