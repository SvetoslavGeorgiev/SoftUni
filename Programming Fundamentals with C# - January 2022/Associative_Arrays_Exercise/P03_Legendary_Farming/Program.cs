using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var keyMaterials = new Dictionary<string, int>();
            var junkMaterials = new Dictionary<string, int>();

            keyMaterials.Add("shards", 0);
            keyMaterials.Add("motes", 0);
            keyMaterials.Add("fragments", 0);
            var firstToRach250 = string.Empty;
            var obtained = string.Empty;

            while (obtained == string.Empty)
            {
                var materials = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
                for (int i = 0; i < materials.Count; i += 2)
                {
                    var currentMatirial = materials[i + 1].ToLower();
                    var currentQuantity = int.Parse(materials[i]);

                    if (keyMaterials.ContainsKey(currentMatirial))
                    {
                        keyMaterials[currentMatirial] += currentQuantity;
                        if (keyMaterials[currentMatirial] >= 250)
                        {
                            keyMaterials[currentMatirial] -= 250;
                            firstToRach250 = currentMatirial;
                            break;
                        }
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(currentMatirial))
                        {
                            junkMaterials[currentMatirial] += currentQuantity;
                        }
                        else
                        {
                            junkMaterials.Add(currentMatirial, currentQuantity);
                        }
                    }
                }

                switch (firstToRach250)
                {
                    case "shards":
                        obtained = "Shadowmourne";
                        break;
                    case "fragments":
                        obtained = "Valanyr";
                        break;
                    case "motes":
                        obtained = "Dragonwrath";
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"{obtained} obtained!");

            foreach (var keyMaterial in keyMaterials)
            {
                Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
            }

            foreach (var junkMaterial in junkMaterials)
            {
                Console.WriteLine($"{junkMaterial.Key}: {junkMaterial.Value}");
            }
        }
    }
}
