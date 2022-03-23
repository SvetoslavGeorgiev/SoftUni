using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var participants = Console.ReadLine();
            var command = string.Empty;

            var dict = new Dictionary<string, int>();
            var sum = 0;
            var name = string.Empty;

            while ((command = Console.ReadLine()) != "end of race")
            {
                var matches = Regex.Matches(command, @"\w");

                var list = matches.Cast<Match>().Select(x => x.Value).ToList();

                

                foreach (var item in list)
                {

                    if (char.IsLetter(char.Parse(item)))
                    {

                        name += item;
                    }
                    else
                    {
                        sum += int.Parse(item);
                    }
                }
                if (participants.Contains(name))
                {
                    if (dict.Keys.Contains(name))
                    {
                        dict[name] = dict[name] + sum;
                    }
                    else
                    {
                        dict.Add(name, sum);
                    }
                }
                name = string.Empty;
                sum = 0;

            }
            var sortedDict = dict.OrderByDescending(x => x.Value);

            var counter = 0;

            foreach (var item in sortedDict)
            {
                counter++;
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                }
                else
                {
                    return;
                }
            }
        }
    }
}
