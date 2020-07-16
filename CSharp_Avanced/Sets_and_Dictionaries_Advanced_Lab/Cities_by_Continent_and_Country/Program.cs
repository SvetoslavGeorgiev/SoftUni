using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
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

            foreach (var continentKvp in continents)
            {
                var continent = continentKvp.Key;
                Console.WriteLine($"{continent}:");

                foreach (var countryKvp in continentKvp.Value)
                {
                    var country = countryKvp.Key;
                    var cities = countryKvp.Value;
                    Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");

                    //second variant with "for" loop!!!
                    //Console.WriteLine($"  {country} -> ");
                    //for (int i = 0; i < cities.Count; i++)
                    //{
                    //    if (i != cities.Count - 1)
                    //    {
                    //        Console.Write($"{cities[i]}, ");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine($"{cities[i]}");
                    //    }

                    //}
                }
            }
        }
    }
}
