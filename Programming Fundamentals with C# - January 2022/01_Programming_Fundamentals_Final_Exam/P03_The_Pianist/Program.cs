using System;
using System.Collections.Generic;

namespace P03_The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var NumberOfTheInitialPieces = int.Parse(Console.ReadLine());

            var pieces = new Dictionary<string, Dictionary<string, string>>();

            

            for (int i = 0; i < NumberOfTheInitialPieces; i++)
            {
                var tokens = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                var piece = tokens[0];
                var composer = tokens[1];
                var key = tokens[2];

                pieces.Add(piece, new Dictionary<string, string>());

                pieces[piece].Add(key, composer);
            }

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {

                var tokens = command.Split("|", StringSplitOptions.RemoveEmptyEntries);

                var action = tokens[0];
                var piece = tokens[1];

                if (action == "Add")
                {

                    var composer = tokens[2];
                    var key = tokens[3];


                    if (!pieces.ContainsKey(piece))
                    {
                        pieces.Add(piece, new Dictionary<string, string>());

                        pieces[piece].Add(key, composer);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    

                }
                else if(action == "ChangeKey")
                {
                    var key = tokens[2];
                    if (pieces.ContainsKey(piece))
                    {
                        foreach (var kvp in pieces)
                        {

                            foreach ( var item in kvp.Value)
                            {
                                if (kvp.Key == piece )
                                {

                                    var composer = item.Value;
                                    pieces[piece].Remove(item.Key);
                                    pieces[piece].Add(key, composer);
                                    Console.WriteLine($"Changed the key of {piece} to {key}!");
                                    break;
                                }
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }


            foreach (var piece in pieces)
            {
                var pieceName = piece.Key;

                foreach (var kvp in piece.Value)
                {
                    var composer = kvp.Value;
                    var key = kvp.Key;

                    Console.WriteLine($"{pieceName} -> Composer: {composer}, Key: {key}");
                }
            }
        }
    }
}
