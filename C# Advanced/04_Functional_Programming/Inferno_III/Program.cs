using System;
using System.Collections.Generic;
using System.Linq;

namespace Inferno_III
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var filters = new Dictionary<string, Func<List<int>, List<int>>>();

            string input = Console.ReadLine();
            while (input != "Forge")
            {
                string[] tokens = input.Split(';');
                string command = tokens[0];
                string filterType = tokens[1];
                int parameter = int.Parse(tokens[2]);

                string dictKey = $"{filterType} {parameter}";

                if (command == "Exclude")
                {
                    filters[dictKey] = CreateFunction(filterType, parameter);
                }
                else if (command == "Reverse")
                {
                    filters.Remove(dictKey);
                }

                input = Console.ReadLine();
            }

            List<int> filtered = GetFiltered(gems, filters);
            gems = gems.Where(gem => !filtered.Contains(gem)).ToList();

            Console.WriteLine(string.Join(" ", gems));
        }

        private static List<int> GetFiltered(List<int> gems, Dictionary<string, Func<List<int>, List<int>>> filters)
        {
            List<int> filtered = new List<int>();

            foreach (var pair in filters)
            {
                var filter = pair.Value;
                filtered.AddRange(filter(gems));
            }

            return filtered;
        }

        private static Func<List<int>, List<int>> CreateFunction(string filterType, int parameter)
        {
            switch (filterType)
            {
                case "Sum Left":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int leftGem = index > 0 ? gems[index - 1] : 0;
                        return gem + leftGem == parameter;
                    }).ToList();
                case "Sum Right":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return gem + rightGem == parameter;
                    }).ToList();
                case "Sum Left Right":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int leftGem = index > 0 ? gems[index - 1] : 0;
                        int rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return gem + leftGem + rightGem == parameter;
                    }).ToList();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
