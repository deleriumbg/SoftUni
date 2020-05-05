using System;
using System.Text.RegularExpressions;

namespace Treasure_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	The first four letter word - the name of the street (only letters, should not be preceded or followed by a digit or a letter)
            //=> Negative lookbehind (?<![A-Za-z0-9]) and Negative lookahead (?![A-Za-z0-9])

            //•	All valid instructions are locked between the symbols “#” and “!”. Each of them can stay before or ahead of the instruction block but they should not be repeating! E.g.:
            //“#{instruction pattern}!” or “!{instruction pattern}#”
            //=> ((?<groupName>#)|!) ... (?(groupName)!|#)

            string pattern =
                @"((?<hash>#)|!)[^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?(?(hash)!|#)";

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);
                Match correctMatch = matches[matches.Count / 2];

                string streetName = correctMatch.Groups["streetName"].Value;
                string streetNumber = correctMatch.Groups["streetNumber"].Value;
                string password = correctMatch.Groups["password"].Value;

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
            }
        }
    }
}
