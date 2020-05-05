using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Srubsko_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = null;
            Dictionary<string, Dictionary<string, int>> concerts = new Dictionary<string, Dictionary<string, int>>();
            string pattern = @"([A-Za-z]+\s*[A-Za-z]*\s*[A-Za-z]*)\s+@([A-Za-z]+\s*[A-Za-z]*\s*[A-Za-z]*)\s+(\d+)\s+(\d+)";

            while ((input = Console.ReadLine()) != "End")
            {

                Match match = Regex.Match(input, pattern);
                string singer = null;
                string venue = null;
                int ticketsPrice = 0;
                int ticketsCount = 0;

                if (match.Success)
                {
                    singer = match.Groups[1].ToString().Trim();
                    venue = match.Groups[2].ToString().Trim();
                    ticketsPrice = int.Parse(match.Groups[3].ToString().Trim());
                    ticketsCount = int.Parse(match.Groups[4].ToString().Trim());
                }
                else
                {
                    continue;
                }

                if (!concerts.ContainsKey(venue))
                {
                    concerts.Add(venue, new Dictionary<string, int>());
                }
                if (!concerts[venue].ContainsKey(singer))
                {
                    concerts[venue].Add(singer, ticketsPrice * ticketsCount);
                }
                else
                {
                    concerts[venue][singer] += ticketsPrice * ticketsCount;
                }
            }

            foreach (var place in concerts)
            {
                Console.WriteLine($"{place.Key}");
                foreach (var singer in place.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
