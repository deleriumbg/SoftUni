using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Population_Aggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<string, int> citiesCountByCountry = new SortedDictionary<string, int>();
            Dictionary<string, long> populationByCity = new Dictionary<string, long>();

            while (input != "stop")
            {
                string[] inputArgs = input.Split('\\');
                string firstEntry = inputArgs[0];
                string secondEntry = inputArgs[1];
                long currentPopulation = long.Parse(inputArgs[2]);

                firstEntry = RemoveForbiddenSymbols(firstEntry);
                secondEntry = RemoveForbiddenSymbols(secondEntry);
                string countryName = String.Empty;
                string cityName = String.Empty;

                if (char.IsUpper(firstEntry[0]))
                {
                    countryName = firstEntry;
                    cityName = secondEntry;
                }
                else
                {
                    countryName = secondEntry;
                    cityName = firstEntry;
                }

                if (!citiesCountByCountry.ContainsKey(countryName))
                {
                    citiesCountByCountry[countryName] = 0;
                }
                citiesCountByCountry[countryName]++;

                populationByCity[cityName] = currentPopulation;
                input = Console.ReadLine();
            }

            foreach (var country in citiesCountByCountry.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{country.Key} -> {country.Value}");
            }
            foreach (var city in populationByCity.OrderByDescending(x => x.Value).Take(3))
            {
                Console.WriteLine($"{city.Key} -> {city.Value}");
            }
        }

        private static string RemoveForbiddenSymbols(string entry)
        {
            char[] forbiddenSymbols = "@#$&".ToCharArray();
            StringBuilder result = new StringBuilder();
            foreach (var symbol in entry)
            {
                if (!char.IsDigit(symbol) && !forbiddenSymbols.Contains(symbol))
                {
                    result.Append(symbol);
                }
            }
            return result.ToString();
        }
    }
}
