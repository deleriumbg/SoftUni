using System;
using System.Text.RegularExpressions;

namespace Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string didiPattern = @"[^A-Za-z-]+";
            string bojoPattern = @"[A-Za-z]+-[A-Za-z]+";
            int turn = 1;

            while (true)
            {
                if (turn % 2 != 0)
                {
                    if (Regex.IsMatch(input, didiPattern))
                    {
                        Match match = Regex.Match(input, didiPattern);
                        Console.WriteLine(match.Value);
                        input = input.Substring(match.Index + match.Length);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (Regex.IsMatch(input, bojoPattern))
                    {
                        Match match = Regex.Match(input, bojoPattern);
                        Console.WriteLine(match.Value);
                        input = input.Substring(match.Index + match.Length);
                    }
                    else
                    {
                        return;
                    }
                }
                turn++;
            }
        }
    }
}
