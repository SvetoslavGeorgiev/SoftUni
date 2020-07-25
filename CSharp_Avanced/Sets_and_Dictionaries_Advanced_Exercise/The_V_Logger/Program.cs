using System;
using System.Linq;
using System.Collections.Generic;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vLoggers = new Dictionary<string, List<List<string>>>();
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Statistics")
            {

                var input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var vLogger = input[0];
                var action = input[1];
                var followed = input[2];

                if (action == "joined" && !vLoggers.ContainsKey(vLogger))
                {
                    vLoggers.Add(vLogger, new List<List<string>>());
                    var lists = new List<List<string>>();
                    var followers = new List<string>();
                    var following = new List<string>();
                    lists.Add(followers);
                    lists.Add(following);
                    vLoggers[vLogger] = lists;
                }
                else
                {
                    if (vLoggers.ContainsKey(vLogger) && vLoggers.ContainsKey(followed))
                    {
                        if (vLogger != followed && !vLoggers[vLogger][1].Contains(followed))
                        {
                            vLoggers[followed][0].Add(vLogger);
                            vLoggers[vLogger][1].Add(followed);
                        }
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vLoggers.Count} vloggers in its logs.");

            var orderedVlogers = vLoggers.OrderByDescending(x => x.Value[0].Count).ThenBy(x => x.Value[1].Count);
            var count = 0;
            foreach (var vLoger in orderedVlogers)
            {
                count++;
                Console.Write($"{count}. {vLoger.Key} : ");

                for (int i = 0; i < vLoger.Value.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"{vLoger.Value[i].Count} followers, ");
                    }
                    else
                    {
                        Console.WriteLine($"{vLoger.Value[i].Count} following");
                    }
                }
                if (count == 1)
                {
                    var ordered = vLoger.Value[0].OrderBy(x => x);

                    foreach (var name in ordered)
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }
            }
        }
    }
}
