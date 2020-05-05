using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] demonsInfo = Console.ReadLine().Split(new [] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries);
            List<Demon> demons = new List<Demon>();

            foreach (var currentDemon in demonsInfo)
            {
                Demon demon = new Demon();
                demon.Name = currentDemon.Trim();
                
                foreach (var symbol in demon.Name)
                {
                    string forbiddenSymbols = "0123456789+-*/.";
                    if (!forbiddenSymbols.Contains(symbol))
                    {
                        demon.Health += symbol;
                    }
                }

                // Ex. M3ph+0.5s-0.5t0.0**
                // Match '-' between 0 and 1 time
                // Match a digit between 1 and unlimited times
                // Match '.' between 0 and 1 time
                // Match a digit between 0 and unlimited times
                string numberPattern = @"-?\d+[.]?\d*";

                MatchCollection matches = Regex.Matches(demon.Name, numberPattern);
                double damageSum = 0.0;
                foreach (Match match in matches)
                {
                    damageSum += double.Parse(match.Value);
                    
                }

                foreach (var symbol in demon.Name)
                {
                    if (symbol == '*')
                    {
                        damageSum *= 2;
                    }
                    else if (symbol == '/')
                    {
                        damageSum /= 2;
                    }
                }

                demon.Damage = damageSum;
                demons.Add(demon);
            }

            foreach (var demon in demons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }
        }
    }
}
