using System;
using System.Collections.Generic;

namespace P05_Cities_by_Continent_and_Country
{
    class P05_Cities_by_Continent_and_Country
    {
        static void Main()
        {
            var entries = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < entries; i++)
            {
                var entry = Console.ReadLine().Split();

                var continent = entry[0];
                var country = entry[1];
                var city = entry[2];


                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }
                continents[continent][country].Add(city);
            }

            foreach (var continentKVP in continents)
            {
                var continent = continentKVP.Key;
                Console.WriteLine($"{continent}:");

                foreach (var countryKVP in continentKVP.Value)
                {
                    var country = countryKVP.Key;
                    var cities = countryKVP.Value;
                    Console.Write($"  {country} -> ");
                    for (int i = 0; i < cities.Count; i++)
                    {
                        if (i != cities.Count - 1)
                        {
                            Console.Write($"{cities[i]}, ");
                        }
                        else
                        {
                            Console.WriteLine($"{cities[i]}");
                        }

                    }
                }
            }
        }
    }
}
