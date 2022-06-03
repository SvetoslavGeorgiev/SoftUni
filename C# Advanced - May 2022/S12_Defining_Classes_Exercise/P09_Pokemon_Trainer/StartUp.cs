using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var command = string.Empty;

            var trainerList = new List<Trainer>();

            while ((command = Console.ReadLine()) != "Tournament")
            {
                var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);


                var trainerName = tokens[0];
                var pokemonName = tokens[1];
                var pokemonElement = tokens[2];
                var pokemonHealth = int.Parse(tokens[3]);


                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                
                if (trainerList.Any(x => x.Name == trainerName))
                {
                    foreach (var tr in trainerList)
                    {
                        if (trainerName == tr.Name)
                        {
                            tr.Collection.Add(pokemon);
                        }
                    }
                }
                else
                {
                    var trainer = new Trainer(trainerName, new List<Pokemon> {pokemon});
                    trainerList.Add(trainer);
                }
                
            }

            while ((command = Console.ReadLine()) != "End")
            {

                if (command == "Fire")
                {
                    Tournament(trainerList, command);
                }
                else if (command == "Water")
                {
                    Tournament(trainerList, command);
                }
                else
                {
                    Tournament(trainerList, command);
                }
            }

            foreach (var tr in trainerList.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{tr.Name} {tr.NumberOfBadges} {tr.Collection.Count}");
            }
        }

        private static void Tournament(List<Trainer> trainerList, string command)
        {
            foreach (var tr in trainerList)
            {
                if (tr.Collection.Any(x => x.Element == command))
                {

                    tr.NumberOfBadges++;

                }
                else
                {
                    tr.Collection.Select(x => x.Health -= 10).ToList();
                    var fileredListOfPokemons = tr.Collection.Where(x => x.Health > 0).ToList();
                    tr.Collection = fileredListOfPokemons;
                }
            }
        }

    }
}
