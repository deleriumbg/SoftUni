using System;
using System.Collections.Generic;
using System.Linq;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);
            bool shadowmourneObtained = false;
            bool valanyrObtained = false;
            bool dragonwrathObtained = false;
            string legendary = "";

            while (shadowmourneObtained == false && valanyrObtained == false && dragonwrathObtained == false)
            {
                List<string> input = Console.ReadLine().ToLower().Split(' ').ToList();
                string material = "";
                int quantity = 0;
                for (int i = 0; i < input.Count; i += 2)
                {
                    quantity = int.Parse(input[i]);
                    material = input[i + 1];

                    switch (material)
                    {
                        case "shards":
                            keyMaterials["shards"] += quantity;
                            break;
                        case "fragments":
                            keyMaterials["fragments"] += quantity;
                            break;
                        case "motes":
                            keyMaterials["motes"] += quantity;
                            break;
                        default:
                            if (junk.ContainsKey(material) == false)
                            {
                                junk.Add(material, quantity);
                            }
                            else
                            {
                                junk[material] += quantity;
                            }
                            break;
                    }

                    if (keyMaterials["shards"] >= 250)
                    {
                        shadowmourneObtained = true;
                        legendary = "Shadowmourne";
                        keyMaterials["shards"] -= 250;
                        break;
                    }
                    else if (keyMaterials["fragments"] >= 250)
                    {
                        valanyrObtained = true;
                        legendary = "Valanyr";
                        keyMaterials["fragments"] -= 250;
                        break;
                    }
                    else if (keyMaterials["motes"] >= 250)
                    {
                        dragonwrathObtained = true;
                        legendary = "Dragonwrath";
                        keyMaterials["motes"] -= 250;
                        break;
                    }
                }
            }

            Console.WriteLine($"{legendary} obtained!");
            foreach (var item in keyMaterials.OrderBy(x => x.Key).OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

