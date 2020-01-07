using System;
using System.Collections.Generic;
using System.Linq;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyMatirial = string.Empty;
            var pairKeyMaterials = new Dictionary<string, int>();
            pairKeyMaterials.Add("shards", 0);
            pairKeyMaterials.Add("fragments", 0);
            pairKeyMaterials.Add("motes", 0);
            var junkMaterials = new Dictionary<string, int>();
            bool win = false;

            while (!win)
            {
                List<string> farming = Console.ReadLine()
                    .ToLower()
                    .Split()
                    .ToList();

                for (int i = 0; i < farming.Count - 1; i += 2)
                {
                    if (farming[i + 1] == "shards" || farming[i + 1] == "fragments" || farming[i + 1] == "motes")
                    {
                        if (pairKeyMaterials.ContainsKey(farming[i + 1]))
                        {
                            pairKeyMaterials[farming[i + 1]] += int.Parse(farming[i]);

                            if (pairKeyMaterials[farming[i + 1]] >= 250)
                            {
                                pairKeyMaterials[farming[i + 1]] = pairKeyMaterials[farming[i + 1]] - 250;
                                keyMatirial = farming[i + 1];
                                win = true;
                                break;
                            }
                            //else if (pairKeyMaterials[farming[i + 1]] == 250)
                            //{
                            //    pairKeyMaterials.Remove(farming[i + 1]);
                            //    keyMatirial = farming[i + 1];
                            //    win = true;
                            //    break;
                            //}
                        }
                        else
                        {
                            pairKeyMaterials.Add(farming[i + 1], int.Parse(farming[i]));
                            if (pairKeyMaterials[farming[i + 1]] >= 250)
                            {
                                pairKeyMaterials[farming[i + 1]] = pairKeyMaterials[farming[i + 1]] - 250;
                                keyMatirial = farming[i + 1];
                                win = true;
                                break;
                            }
                            //else if (pairKeyMaterials[farming[i + 1]] == 250)
                            //{
                            //    pairKeyMaterials.Remove(farming[i + 1]);
                            //    keyMatirial = farming[i + 1];
                            //    win = true;
                            //    break;
                            //}
                        }
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(farming[i + 1]))
                        {
                            junkMaterials[farming[i + 1]] += int.Parse(farming[i]);
                        }
                        else
                        {
                            junkMaterials.Add(farming[i + 1], int.Parse(farming[i]));
                        }
                    }
                    
                }
            }

            var legendariItem = string.Empty;
            switch (keyMatirial)
            {
                case "shards":
                    legendariItem = "Shadowmourne";
                        break;
                case "fragments":
                    legendariItem = "Valanyr";
                    break;
                case "motes":
                    legendariItem = "Dragonwrath";
                    break;
            }

            var orderedKeyMaterials = pairKeyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            var orderedJunkMaterials = junkMaterials.OrderBy(x => x.Key);

            Console.WriteLine($"{legendariItem} obtained!");
            foreach (var materials in orderedKeyMaterials)
            {
                Console.WriteLine($"{materials.Key}: {materials.Value}");
            }
            foreach (var materials in orderedJunkMaterials)
            {
                Console.WriteLine($"{materials.Key}: {materials.Value}");
            }
        }
    }
}
