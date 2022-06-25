using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Tiles_Maste
{
    public class P01_Tiles_Master
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var input2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var grayTilesArea = new Queue<int>(input2);
            var whiteTilesArea = new Stack<int>(input);

            
            
            var locations = new Dictionary<string, int>();


            while (grayTilesArea.Any() && whiteTilesArea.Any())
            {
                var newTile = 0;
                var currentWhiteTile = whiteTilesArea.Pop();
                var currentGrayTile = grayTilesArea.Dequeue();



                if (currentGrayTile != currentWhiteTile)
                {
                    whiteTilesArea.Push(currentWhiteTile / 2);
                    grayTilesArea.Enqueue(currentGrayTile);
                }
                else
                {

                    newTile = currentWhiteTile + currentGrayTile;

                    var currentLocation = GetNewTileLocation(newTile);

                    if (locations.ContainsKey(currentLocation))
                    {
                        locations[currentLocation]++;
                    }
                    else
                    {
                        locations.Add(currentLocation, 1);
                    }

                }

            }

            if (!whiteTilesArea.Any())
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTilesArea)}");
            }
            if (!grayTilesArea.Any())
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grayTilesArea)}");
            }
            if (locations.Any())
            {
                foreach (var location in locations.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{location.Key}: {location.Value}");
                }
            }

        }


        public static string GetNewTileLocation(int currentNewTile)
        {
            var location = string.Empty;

            switch (currentNewTile)
            {
                case 40:
                    location = "Sink";
                    break;
                case 50:
                    location = "Oven";
                    break;
                case 60:
                    location = "Countertop";
                    break;
                case 70:
                    location = "Wall";
                    break;
                default:
                    location = "Floor";
                    break;
            }

            return location;

        }
    }
}
