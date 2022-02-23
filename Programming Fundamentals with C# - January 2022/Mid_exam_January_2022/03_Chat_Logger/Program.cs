using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Chat_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;

            var chat = new List<string>();

            while ((command = Console.ReadLine()) != "end")
            {
                var input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var action = input[0];

                var message = input[1];


                if (action == "Chat")
                {
                    chat.Add(message);
                }
                else if (action == "Delete")
                {
                    if (chat.Contains(message))
                    {
                        chat.Remove(message);
                    }
                }
                else if (action == "Edit")
                {
                    if (chat.Contains(message))
                    {
                        var editedMessage = input[2];
                        var indexOfTheMessage = chat.FindIndex(x => x.Contains(message));
                        chat.RemoveAt(indexOfTheMessage);
                        chat.Insert(indexOfTheMessage, editedMessage);
                    }
                }
                else if (action == "Pin")
                {
                    if (chat.Contains(message))
                    {
                        var indexOfTheMessage = chat.FindIndex(x => x.Contains(message));
                        chat.RemoveAt(indexOfTheMessage);
                        chat.Add(message);
                    }
                }
                else if (action == "Spam")
                {
                    input.Remove("Spam");

                    input.ForEach(x => chat.Add(x));
                }
            }

            chat.ForEach(x => Console.WriteLine(x));
        }
    }
}
