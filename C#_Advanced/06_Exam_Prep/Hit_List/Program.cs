using System;
using System.Collections.Generic;
using System.Linq;

namespace Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            var people = new Dictionary<string, SortedDictionary<string, string>>();

            while (input != "end transmissions")
            {
                string[] inputCommand = input.Split('=');
                string name = inputCommand[0];
                string[] kvps = inputCommand[1].Split(';');

                if (!people.ContainsKey(name))
                {
                    people.Add(name, new SortedDictionary<string, string>());
                }

                foreach (var kvp in kvps)
                {
                    string[] kvpTokens = kvp.Split(':');
                    string key = kvpTokens[0];
                    string value = kvpTokens[1];
                    if (!people[name].ContainsKey(key))
                    {
                        people[name].Add(key, value);
                    }
                    else
                    {
                        people[name][key] = value;
                    }
                }

                input = Console.ReadLine();
            }

            string killTarget = Console.ReadLine().Split()[1];

            Console.WriteLine($"Info on {killTarget}:");
            int infoIndex = 0;

            foreach (var person in people.Where(x => x.Key == killTarget))
            {
                foreach (var info in person.Value)
                {
                    Console.WriteLine($"---{info.Key}: {info.Value}");
                    infoIndex += info.Key.Length + info.Value.Length;
                }
            }

            Console.WriteLine($"Info index: {infoIndex}");
            Console.WriteLine(infoIndex >= targetInfoIndex
                ? "Proceed"
                : $"Need {targetInfoIndex - infoIndex} more info.");
        }
    }
}
