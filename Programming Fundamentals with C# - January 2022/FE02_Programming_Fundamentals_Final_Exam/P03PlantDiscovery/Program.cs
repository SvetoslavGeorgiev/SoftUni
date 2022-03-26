using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var plantRarity = new Dictionary<string, int>();
            var plantRatings = new Dictionary<string, List<double>>();

            PlantsNameAndRarity(plantRarity);

            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                var currentCommand = command
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var type = currentCommand[0];
                var plantInfo = currentCommand[1]
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var plantName = plantInfo[0];
                if (type == "Rate")
                {
                    double plantRating = double.Parse(plantInfo[1]);

                    AddPlantRating(plantRarity, plantRatings, plantName, plantRating);
                }
                else if (type == "Update")
                {
                    int newRarity = int.Parse(plantInfo[1]);

                    UpdateRarity(plantRarity, plantName, newRarity);
                }
                else if (type == "Reset")
                {
                    ResetEntry(plantRarity, plantRatings, plantName);
                }
            }

            PrintOutputInformation(plantRarity, plantRatings);
        }

        static void PrintOutputInformation(Dictionary<string, int> plantRarity,
            Dictionary<string, List<double>> plantRatings)
        {
            Console.WriteLine($"Plants for the exhibition:");
            foreach (KeyValuePair<string, int> kvp in plantRarity)
            {
                string plantName = kvp.Key;
                int rarity = kvp.Value;
                double avgRating = 0;

                if (plantRatings.ContainsKey(plantName) && plantRatings[plantName].Any())
                {
                    avgRating = plantRatings[plantName].Average();
                }

                Console.WriteLine($"- {plantName}; Rarity: {rarity}; Rating: {avgRating:f2}");
            }
        }

        static void ResetEntry(Dictionary<string, int> plantRarity,
            Dictionary<string, List<double>> plantRatings, string plantName)
        {
            if (!plantRarity.ContainsKey(plantName))
            {
                Console.WriteLine("error");
                return;
            }

            if (plantRatings.ContainsKey(plantName))
            {
                plantRatings[plantName].Clear();
            }
        }

        static void UpdateRarity(Dictionary<string, int> plantRarity, string plantName, int newRarity)
        {
            if (plantRarity.ContainsKey(plantName))
            {
                plantRarity[plantName] = newRarity;
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        static void AddPlantRating(Dictionary<string, int> plantRarity,
            Dictionary<string, List<double>> plantRatings, string plantName, double rating)
        {
            if (!plantRarity.ContainsKey(plantName))
            {
                Console.WriteLine("error");
                return;
            }

            if (!plantRatings.ContainsKey(plantName))
            {
                plantRatings[plantName] = new List<double>();
            }

            plantRatings[plantName].Add(rating);
        }

        static void PlantsNameAndRarity(Dictionary<string, int> plantRarity)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] plants = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string plantName = plants[0];
                int rarity = int.Parse(plants[1]);

                plantRarity[plantName] = rarity;
            }
        }
    }
}