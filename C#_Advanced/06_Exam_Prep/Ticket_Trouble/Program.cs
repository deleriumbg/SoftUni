using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ticket_Trouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string curlyBrackets = @"{[^}]*\[([A-Z]{3} [A-Z]{2})].*?\[([A-Z]{1}[0-9]{1,2})\][^{]*}";
            string squareBrackets = @"\[[^]]*{([A-Z]{3} [A-Z]{2})}.*?{([A-Z]{1}[0-9]{1,2})}[^[]*]";
            List<string> seats = new List<string>();

            string location = Console.ReadLine();
            string input = Console.ReadLine();

            MatchCollection squareMatches = Regex.Matches(input, squareBrackets);
            MatchCollection curlyMatches = Regex.Matches(input, curlyBrackets);

            AddSeats(squareMatches, seats, location);
            AddSeats(curlyMatches, seats, location);

            if (seats.Count == 2)
            {
                Console.WriteLine($"You are traveling to {location} on seats {seats[0]} and {seats[1]}.");
            }
            else
            {
                for (int i = 0; i < seats.Count; i++)
                {
                    for (int j = i + 1; j < seats.Count; j++)
                    {
                        string firstSeat = seats[i].Substring(1);
                        string secondSeat = seats[j].Substring(1);
                        if (firstSeat == secondSeat)
                        {
                            Console.WriteLine($"You are traveling to {location} on seats {seats[i]} and {seats[j]}.");
                            return;
                        }
                    }
                }
            }
        }

        private static void AddSeats(MatchCollection matches, List<string> seats, string location)
        {
            foreach (Match match in matches)
            {
                if (match.Groups[1].Value.Contains(location))
                {
                    seats.Add(match.Groups[2].Value);
                }
            }
        }
    }
}
