using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Blacksmith
{
    public class P01_Blacksmith
    {
        static void Main()
        {
            var steel = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            var carbon = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            var swords = new Dictionary<string, int>(); 

            while (steel.Any() && carbon.Any())
            {
                var currentSteel = steel.Dequeue();
                var currentCarbon = carbon.Pop();

                var sword = GetSword(currentSteel + currentCarbon);

                if (sword != null)
                {
                    if (swords.ContainsKey(sword))
                    {
                        swords[sword]++;
                    }
                    else
                    {
                        swords.Add(sword, 1);
                    }
                }
                else
                {
                    currentCarbon += 5;
                    carbon.Push(currentCarbon);
                }
            }

            if (swords.Any())
            {
                Console.WriteLine($"You have forged {swords.Sum(x => x.Value)} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Any())
            {
                Console.WriteLine($"Steel left: { string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbon.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
            foreach (var sword in swords.OrderBy(x => x.Key))
            {

                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }

        }

        private static string GetSword(int resource)
        {
            var sword = string.Empty;

            switch (resource)
            {
                case 70:
                    sword = "Gladius";
                    break;
                case 80:
                    sword = "Shamshir";
                    break;
                case 90:
                    sword = "Katana";
                    break;
                case 110:
                    sword = "Sabre";
                    break;
                case 150:
                    sword = "Broadsword";
                    break;
                default:
                    sword = null;
                    break;
            }

            return sword;
        }
    }
}
