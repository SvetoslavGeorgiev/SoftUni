using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P05_Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var demons = Regex.Split(input, @" *,{1} *").ToList();

            var patern = @"[^+\/\-*.0-9]";

            var demonsBook = new Dictionary<string, KeyValuePair<int, double>>();


            foreach (var demon in demons)
            {
                var sum = 0;
                var damage = 0.00;

                

                if (Regex.IsMatch(demon, patern))
                {
                    var matches = Regex.Matches(demon, patern);

                    foreach (Match match in matches)
                    {
                        var asciiValue = char.Parse(match.Value);

                        sum += asciiValue;
                    }
                }

                var patern2 = @"([+-]?(\d+\.)?\d+)";

                if (Regex.IsMatch(demon, patern2))
                {
                    var matches = Regex.Matches(demon, patern2);

                    foreach (Match match in matches)
                    {
                        damage += double.Parse(match.Value);
                    }
                }

                var patern3 = @"[\*\/]";

                if (Regex.IsMatch(demon, patern3))
                {
                    var matches = Regex.Matches(demon, patern3);

                    foreach (Match match in matches)
                    {
                        if (match.Value == "*")
                        {
                            damage *= 2;
                        }
                        else
                        {
                            damage /= 2;
                        }
                    }
                }
                demonsBook[demon] = new KeyValuePair<int, double>(sum, damage);
            }

            var sortedDictionary = demonsBook.OrderBy(x => x.Key).ToList();

            foreach (var item in sortedDictionary)
            {
                var name = item.Key;

                //foreach (var item in kvp.Value)
                //{

                //    var health = item.Key;
                //    var damage = item.Value;
                //    Console.WriteLine($"{name} - {health} health, {damage:F2} damage");
                //}
                Console.WriteLine($"{name} - {item.Value.Key} health, {item.Value.Value:F2} damage");
            }
        }
    }
}
