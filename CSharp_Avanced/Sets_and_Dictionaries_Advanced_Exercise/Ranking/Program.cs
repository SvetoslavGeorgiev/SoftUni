using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;

            var contests = new Dictionary<string, string>();
            var candidates = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of contests")
            {
                var currentInput = input.Split(':').ToArray();
                var contest = currentInput[0];
                var password = currentInput[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {

                var currentInput = input.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var contest = currentInput[0];
                var password = currentInput[1];
                var candidate = currentInput[2];
                var points = int.Parse(currentInput[3]);

                if (contests.ContainsKey(contest) && contests[contest].Contains(password))
                {
                    if (!candidates.ContainsKey(candidate))
                    {
                        candidates.Add(candidate, new Dictionary<string, int>());
                        candidates[candidate].Add(contest, points);
                    }
                    else if (candidates.ContainsKey(candidate) && !candidates[candidate].ContainsKey(contest))
                    {
                        candidates[candidate].Add(contest, points);
                    }
                    else if (candidates.ContainsKey(candidate) &&
                             candidates[candidate].ContainsKey(contest) &&
                             candidates[candidate][contest] < points)
                    {
                        candidates[candidate][contest] = points;
                    }
                }
            }
            var sum = 0;
            var name = string.Empty;
            foreach (var canndidateKvp in candidates)
            {
                var currentSum = canndidateKvp.Value.Sum(x => x.Value);
                if (currentSum > sum)
                {
                    sum = currentSum;
                    name = canndidateKvp.Key;
                }
            }
            var ordaredCandidates = candidates.OrderBy(x => x.Key);

            Console.WriteLine($"Best candidate is {name} with total {sum} points.");
            Console.WriteLine("Ranking:");

            foreach (var candidatesKvp in ordaredCandidates)
            {
                Console.WriteLine(candidatesKvp.Key);
                foreach (var kvp in candidatesKvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
