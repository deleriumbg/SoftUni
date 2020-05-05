using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            long goldQuantity = 0;
            Dictionary<string, long> gems = new Dictionary<string, long>();
            Dictionary<string, long> cash = new Dictionary<string, long>();

            for (int i = 0; i < sequence.Length - 1; i+=2)
            {
                string item = sequence[i];
                long quantity = long.Parse(sequence[i + 1]);

                if (item.ToLower() == "gold" && bagCapacity >= quantity)
                {
                    goldQuantity += quantity;
                    bagCapacity -= quantity;
                }
                else if (item.ToLower().EndsWith("gem") && bagCapacity >= quantity && quantity + gems.Values.Sum() <= goldQuantity)
                {
                    if (!gems.ContainsKey(item))
                    {
                        gems.Add(item, quantity);
                    }
                    else
                    {
                        gems[item] += quantity;
                    }

                    bagCapacity -= quantity;
                }
                else if (item.Length == 3 && bagCapacity >= quantity && quantity + cash.Values.Sum() <= gems.Values.Sum())
                {
                    if (!cash.ContainsKey(item))
                    {
                        cash.Add(item, quantity);
                    }
                    else
                    {
                        cash[item] += quantity;
                    }

                    bagCapacity -= quantity;
                }
            }

            if (goldQuantity > 0)
            {
                Console.WriteLine($"<Gold> ${goldQuantity}\r\n##Gold - {goldQuantity}");
            }

            if (gems.Any())
            {
                Console.WriteLine($"<Gem> ${gems.Values.Sum()}");
                foreach (var gem in gems.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{gem.Key} - {gem.Value}");
                }
            }

            if (cash.Any())
            {
                Console.WriteLine($"<Cash> ${cash.Values.Sum()}");
                foreach (var currency in cash.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{currency.Key} - {currency.Value}");
                }
            }
        }
    }
}
