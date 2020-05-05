using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy_Times
{
    public class Program
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string[] itemQuantityPair = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = InitializeBag(out long gold, out long gems, out long cash);
            TakeSafeContent(itemQuantityPair, input, bag, gold, gems, cash);
            PrintStolenItems(bag);
        }

        private static void PrintStolenItems(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var item in bag)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");
                foreach (var item2 in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private static void TakeSafeContent(string[] itemQuantityPair, long input, Dictionary<string, Dictionary<string, long>> bag, long gold, long gems,
            long cash)
        {
            for (int i = 0; i < itemQuantityPair.Length; i += 2)
            {
                string item = itemQuantityPair[i];
                long quantity = long.Parse(itemQuantityPair[i + 1]);

                string itemType = string.Empty;

                itemType = GetItemType(item, itemType);

                if (itemType == "")
                {
                    continue;
                }

                if (input < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gem":
                        if (!bag.ContainsKey(itemType))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (quantity > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[itemType].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }

                        break;
                    case "Cash":
                        if (!bag.ContainsKey(itemType))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (quantity > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[itemType].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }

                        break;
                }
                gold = FillTheBag(bag, gold, ref gems, ref cash, itemType, item, quantity);
            }
        }

        private static long FillTheBag(Dictionary<string, Dictionary<string, long>> bag, long gold, ref long gems, ref long cash, string itemType, string item,
            long quantity)
        {
            if (!bag.ContainsKey(itemType))
            {
                bag[itemType] = new Dictionary<string, long>();
            }

            if (!bag[itemType].ContainsKey(item))
            {
                bag[itemType][item] = 0;
            }

            bag[itemType][item] += quantity;
            switch (itemType)
            {
                case "Gold":
                    gold += quantity;
                    break;
                case "Gem":
                    gems += quantity;
                    break;
                case "Cash":
                    cash += quantity;
                    break;
            }
            return gold;
        }

        private static string GetItemType(string item, string itemType)
        {
            if (item.Length == 3)
            {
                itemType = "Cash";
            }
            else if (item.ToLower().EndsWith("gem"))
            {
                itemType = "Gem";
            }
            else if (item.ToLower() == "gold")
            {
                itemType = "Gold";
            }

            return itemType;
        }

        private static Dictionary<string, Dictionary<string, long>> InitializeBag(out long gold, out long gems, out long cash)
        {
            var bag = new Dictionary<string, Dictionary<string, long>>();
            gold = 0;
            gems = 0;
            cash = 0;
            return bag;
        }
    }
}