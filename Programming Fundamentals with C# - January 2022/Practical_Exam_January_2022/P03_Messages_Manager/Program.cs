using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Messages_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());


            var command = string.Empty;


            var dic = new Dictionary<string, List<int>>();
            var usersInOrderOfInput = new List<string>();

            while ((command = Console.ReadLine()) != "Statistics")
            {

                var tokens = command.Split('=', StringSplitOptions.RemoveEmptyEntries);

                var action = tokens[0];

                if (action == "Add")
                {

                    var user = tokens[1];
                    var send = int.Parse(tokens[2]);
                    var received = int.Parse(tokens[3]);

                    if (!dic.ContainsKey(user))
                    {
                        usersInOrderOfInput.Add(user);
                        dic.Add(user, new List<int>());
                        dic[user].Add(send);
                        dic[user].Add(received);
                    }
                }
                else if (action == "Message")
                {
                    var sender = tokens[1];
                    var receiver = tokens[2];

                    if (dic.ContainsKey(sender) && dic.ContainsKey(receiver))
                    {
                        
                        dic[sender][0] += 1;
                        dic[receiver][1] += 1;

                        var senderSum = dic[sender].Sum();
                        var receiverSum = dic[receiver].Sum();

                        if (senderSum >= maxCapacity)
                        {
                            usersInOrderOfInput.Remove(sender);
                            dic.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        if (receiverSum >= maxCapacity)
                        {
                            usersInOrderOfInput.Remove(receiver);
                            dic.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }
                else
                {
                    var user = tokens[1];

                    if (user == "All")
                    {
                        dic.Clear();
                        usersInOrderOfInput.Clear();
                    }
                    else
                    {
                        if (dic.ContainsKey(user))
                        {
                            dic.Remove(user);
                            usersInOrderOfInput.Remove(user);
                        }
                    }
                }
            }

            Console.WriteLine($"Users count: {dic.Count}");
            foreach (var item in usersInOrderOfInput)
            {
                foreach (var kvp in dic)
                {

                    if (item == kvp.Key)
                    {
                        Console.WriteLine($"{item} - {kvp.Value.Sum()}");
                        break;
                    }
                }
            }
        }
    }
}
