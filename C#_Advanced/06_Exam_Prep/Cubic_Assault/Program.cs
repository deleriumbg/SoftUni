using System;
using System.Collections.Generic;
using System.Linq;

namespace Cubic_Assault
{
    class Program
    {
        private const int MeteorOverflowIndex = 1_000_000;

        static void Main(string[] args)
        {
            var meteors = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();

            while (input != "Count em all")
            {
                string[] inputArgs = input.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                string region = inputArgs[0];
                string meteorType = inputArgs[1];
                long meteorCount = long.Parse(inputArgs[2]);

                if (!meteors.ContainsKey(region))
                {
                    meteors.Add(region, new Dictionary<string, long>()
                    {
                        { "Red", 0 },
                        { "Black", 0 },
                        { "Green", 0 }
                    });
                }

                meteors[region][meteorType] += meteorCount;
                if (meteorType == "Green" && meteors[region]["Green"] >= MeteorOverflowIndex)
                {
                    meteors[region]["Red"] += meteors[region]["Green"] / MeteorOverflowIndex;
                    meteors[region]["Green"] %= MeteorOverflowIndex;
                }
                if (meteorType == "Red" && meteors[region]["Red"] >= MeteorOverflowIndex)
                {
                    meteors[region]["Black"] += meteors[region]["Red"] / MeteorOverflowIndex;
                    meteors[region]["Red"] %= MeteorOverflowIndex;
                }

                input = Console.ReadLine();
            }

            foreach (var region in meteors.OrderByDescending(x => x.Value["Black"])
                .ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var meteor in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }
    }
}
