using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Match_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            MatchCollection matches = Regex.Matches(input, pattern);
            string[] result = matches.Cast<Match>().Select(x => x.Value).ToArray();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
