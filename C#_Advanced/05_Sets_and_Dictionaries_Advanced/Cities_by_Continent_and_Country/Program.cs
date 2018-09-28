using System;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int entryCount = int.Parse(Console.ReadLine());
            var cityInfo = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < entryCount; i++)
            {
                string[] cityInput = Console.ReadLine().Split();
                string continent = cityInput[0];
                string country = cityInput[1];
                string city = cityInput[2];

                if (!cityInfo.ContainsKey(continent))
                {
                    cityInfo.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!cityInfo[continent].ContainsKey(country))
                {
                    cityInfo[continent][country] = new List<string>();
                }
                cityInfo[continent][country].Add(city);
            }

            foreach (var continent in cityInfo)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
