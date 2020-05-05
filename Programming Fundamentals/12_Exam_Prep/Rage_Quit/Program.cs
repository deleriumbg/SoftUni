using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            string pattern = @"([^0-9]+)([0-9]*)";

            MatchCollection matches = Regex.Matches(input, pattern);
            StringBuilder result = new StringBuilder();

            foreach (Match match in matches)
            {
                int iterations = int.Parse(match.Groups[2].Value);
                for (int i = 0; i < iterations; i++)
                {
                    result.Append(match.Groups[1].Value);
                }
            }

            string resultString = result.ToString();
            Console.WriteLine($"Unique symbols used: {resultString.Distinct().Count()}");
            Console.WriteLine(resultString);
        }
    }
}
