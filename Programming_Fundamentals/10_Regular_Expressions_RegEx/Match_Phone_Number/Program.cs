using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(\+359)([ -]{1})2\2([0-9]{3})\2([0-9]{4})\b";
            MatchCollection matches = Regex.Matches(input, pattern);
            string[] phoneMatches = matches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();
            Console.WriteLine(string.Join(", ", phoneMatches));
        }
    }
}
