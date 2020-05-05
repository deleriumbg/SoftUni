using System;
using System.Collections.Generic;
using System.Linq;

namespace Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> countryReport = new Dictionary<string, Dictionary<string, long>>();
            
            while (input != "report")
            {
                string[] cityArgs = input.Split('|');
                string cityName = cityArgs[0];
                string country = cityArgs[1];
                long population = long.Parse(cityArgs[2]);

                if (!countryReport.ContainsKey(country))
                {
                    countryReport[country] = new Dictionary<string, long>();
                }
                countryReport[country][cityName] = population;
                input = Console.ReadLine();
            }

            foreach (var pair in countryReport.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{pair.Key} (total population: {pair.Value.Values.Sum()})");
                foreach (var city in pair.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
