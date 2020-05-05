using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int messagesCount = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int currentMessage = 0; currentMessage < messagesCount; currentMessage++)
            {
                string input = Console.ReadLine();
                int count = input.Count(t => t == 's' || t == 'S' || t == 't' || t == 'T' || t == 'a' || t == 'A' || t == 'r' || t == 'R');

                StringBuilder decryptedMessage = new StringBuilder();
                foreach (var symbol in input)
                {
                    int charAscii = symbol - count;
                    decryptedMessage.Append((char)charAscii);
                }
                string decryptedString = decryptedMessage.ToString();

                // The planet name starts after '@' and contains only letters from the Latin alphabet. 
                // The planet population starts after ':' and is an Integer;
                // The attack type may be "A"(attack) or "D"(destruction) and must be surrounded by "!"(exclamation mark).
                // The soldier count starts after "->" and should be an Integer.

                string pattern = @"@([A-Za-z]+)[^@\-!:>]*:([\d]+)[^@\-!:>]*!([AD])!.*->([\d]+)";

                MatchCollection matches = Regex.Matches(decryptedString, pattern);
                foreach (Match match in matches)
                {
                    if (match.Groups[3].Value == "A")
                    {
                        attackedPlanets.Add(match.Groups[1].Value);
                    }
                    else if (match.Groups[3].Value == "D")
                    {
                        destroyedPlanets.Add(match.Groups[1].Value);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            if (attackedPlanets.Count > 0)
            {
                foreach (var planet in attackedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            if (destroyedPlanets.Count > 0)
            {
                foreach (var planet in destroyedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
        }
    }
}
