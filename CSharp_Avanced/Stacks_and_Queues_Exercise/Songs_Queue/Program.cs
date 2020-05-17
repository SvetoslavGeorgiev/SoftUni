using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");

            Queue<string> playList = new Queue<string>(input);

            while (playList.Any())
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "Play")
                {
                    playList.Dequeue();
                }
                else if (command[0] == "Show")
                {
                    if (playList.Count > 1)
                    {
                        var numberOfSongInTheList = playList.Count;
                        var currentSong = string.Empty;
                        for (int i = 1; i <= numberOfSongInTheList; i++)
                        {
                            currentSong = playList.Dequeue();
                            if (i != numberOfSongInTheList)
                            {
                                Console.Write($"{currentSong}, ");
                                playList.Enqueue(currentSong);
                            }
                            else
                            {
                                Console.Write(currentSong);
                                playList.Enqueue(currentSong);
                                Console.WriteLine();
                            }
                        }
                    }
                    else if (playList.Count == 1)
                    {
                        Console.WriteLine(playList.Peek());
                    }
                }
                else
                {
                    var song = new StringBuilder();
                    for (int i = 1; i < command.Length; i++)
                    {
                        if (i != command.Length - 1)
                        {
                            song.Append($"{command[i]} ");
                        }
                        else
                        {
                            song.Append(command[i]);
                        }
                    }
                    if (!playList.Contains(song.ToString()))
                    {
                        playList.Enqueue(song.ToString());
                    }
                    else
                    {
                        Console.WriteLine($"{song.ToString()} is already contained!");
                    }
                }

            }

            Console.WriteLine("No more songs!");
        }
    }
}
