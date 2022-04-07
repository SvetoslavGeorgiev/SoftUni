using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var command = string.Empty;

            var rangList = new Dictionary<string, Dictionary<string, int>>();

            var totalPoints = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "Season end")
            {
                var isTrue = command.Contains("vs");

                if (!isTrue)
                {

                    var tokens = command.Split(" -> ");

                    var player = tokens[0];
                    var position = tokens[1];
                    var skillPoints = int.Parse(tokens[2]);



                    if (!rangList.ContainsKey(player))
                    {
                        totalPoints.Add(player, skillPoints);
                        rangList.Add(player, new Dictionary<string, int>());
                        rangList[player].Add(position, skillPoints);

                    }
                    else
                    {

                        if (!rangList[player].ContainsKey(position))
                        {
                            rangList[player].Add(position, skillPoints);
                            totalPoints[player] += skillPoints;
                        }
                        else
                        {

                            if (rangList[player][position] < skillPoints)
                            {
                                rangList[player][position] = skillPoints;
                            }

                        }

                    }

                }
                else
                {

                    var tokens = command.Split(" vs ");

                    var player1 = tokens[0];
                    var player2 = tokens[1];

                    if (rangList.ContainsKey(player1) && rangList.ContainsKey(player2))
                    {

                        var hasCommons = false;

                        foreach (var kvp in rangList[player1])
                        {
                            
                            foreach (var item in rangList[player2])
                            {
                                if (kvp.Key == item.Key)
                                {
                                    hasCommons = true;
                                }
                            }
                        }

                        if (hasCommons && totalPoints[player1] != totalPoints[player2])
                        {

                            if (totalPoints[player1] > totalPoints[player2])
                            {
                                rangList.Remove(player2);
                                totalPoints.Remove(player2);
                            }
                            else if(totalPoints[player1] < totalPoints[player2])
                            {
                                rangList.Remove(player1);
                                totalPoints.Remove(player1);
                            }
                        }
                    }
                }
            }

            foreach (var kvp in totalPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {

                Console.WriteLine($"{kvp.Key}: {kvp.Value} skill");


                foreach (var item in rangList[kvp.Key].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {

                    Console.WriteLine($"- {item.Key} <::> {item.Value}");

                }
            }
        }
    }
}
