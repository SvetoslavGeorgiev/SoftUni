using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            var listForTheParty = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split().ToList();

                if (input.Contains("not"))
                {
                    if (listForTheParty.Contains(input[0]))
                    {
                        listForTheParty.Remove(input[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{input[0]} is not in the list!");
                    }
                }
                else
                {
                    if (listForTheParty.Contains(input[0]))
                    {
                        Console.WriteLine($"{input[0]} is already in the list!");
                    }
                    else
                    {
                        listForTheParty.Add(input[0]);
                    }
                }
            }
            listForTheParty.ForEach(x => Console.WriteLine(x));
        }
    }
}
