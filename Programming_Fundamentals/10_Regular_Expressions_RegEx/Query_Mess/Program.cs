using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Query_Mess
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([^&=?]*)=([^&=]*)";

            while (input != "END")
            {
                var result = new Dictionary<string, List<string>>();
                MatchCollection matches = Regex.Matches(input, pattern);

                foreach (Match match in matches)
                {
                    string key = Regex.Replace(match.Groups[1].Value, @"((%20|\+)+)", " ").Trim();
                    string value = Regex.Replace(match.Groups[2].Value, @"((%20|\+)+)", " ").Trim();

                    if (!result.ContainsKey(key))
                    {
                        result.Add(key, new List<string>());
                    }
                    result[key].Add(value);
                }

                foreach (var entry in result)
                {
                    Console.Write($"{entry.Key}=[{string.Join(", ", entry.Value)}]");
                }
                Console.WriteLine();

                input = Console.ReadLine();
            }
        }
    }
}