using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Weather
{
    class Weather
    {
        public double Temperature { get; set; }
        public string weatherType { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<town>[A-Z]{2})(?<temp>[0-9]+\.[0-9]+)(?<weather>[A-Za-z]+)\|";
            Dictionary<string, Weather> forecast = new Dictionary<string, Weather>();
            while (input != "end")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    string town = match.Groups["town"].ToString();
                    double temp = double.Parse(match.Groups["temp"].ToString());
                    string weatherType = match.Groups["weather"].ToString();
                    Weather weather = new Weather();
                    weather.Temperature = temp;
                    weather.weatherType = weatherType;
                    forecast[town] = weather;
                }
                input = Console.ReadLine();
            }

            foreach (var town in forecast.OrderBy(x => x.Value.Temperature))
            {
                Console.WriteLine($"{town.Key} => {town.Value.Temperature:f2} => {town.Value.weatherType}");
            }
        }
    }
}
