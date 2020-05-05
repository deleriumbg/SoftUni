using System;
using System.Text.RegularExpressions;

namespace Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new []{' ', ','},StringSplitOptions.RemoveEmptyEntries);
            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    string firstPart = ticket.Substring(0, 10);
                    string secondPart = ticket.Substring(10);

                    string pattern = @"@{6,10}|\^{6,10}|#{6,10}|\${6,10}";
                    if (Regex.IsMatch(firstPart, pattern) && Regex.IsMatch(secondPart, pattern))
                    {
                        Match firstMatch = Regex.Match(firstPart, pattern);
                        Match secondMatch = Regex.Match(secondPart, pattern);
                        if (firstMatch.Value[0] != secondMatch.Value[0])
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                            continue;
                        }
                        if (firstMatch.Value.Length == 10 && secondMatch.Value.Length == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - 10{ticket[0]} Jackpot!");
                        }
                        else
                        {
                            int matchLength = Math.Min(firstMatch.Value.Length, secondMatch.Value.Length);
                            Console.WriteLine($"ticket \"{ticket}\" - {matchLength}{firstMatch.Value[0]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
            }
        }
    }
}
