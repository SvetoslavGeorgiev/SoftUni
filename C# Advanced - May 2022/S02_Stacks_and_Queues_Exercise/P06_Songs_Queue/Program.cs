using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06_Songs_Queue
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
                    if (playList.Any())
                    {
                        Console.WriteLine(string.Join(", ", playList));
                    }
                }
                else
                {
                    var que = new Queue<string>(command);
                    que.Dequeue();
                    var song = string.Join(" ", que);
                    if (!playList.Contains(song))
                    {
                        playList.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }

            }

            Console.WriteLine("No more songs!");
        }
    }
}
