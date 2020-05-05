using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Key_Replacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyString = Console.ReadLine();
            string keyPattern = @"^(?<start>[A-Za-z]*)([\\<\|]{1}).*([\\<\|]{1})(?<end>[A-Za-z]*)$";
            Match keyMatch = Regex.Match(keyString, keyPattern);
            string start = keyMatch.Groups["start"].Value;
            string end = keyMatch.Groups["end"].Value;

            string input = Console.ReadLine();
            string pattern = $@"{start}(.*?){end}";
            MatchCollection result = Regex.Matches(input, pattern);
            StringBuilder sb = new StringBuilder();
            foreach (Match match in result)
            {
                sb.Append(match.Groups[1].Value);
            }
            Console.WriteLine(sb.ToString().Length > 0 ? sb.ToString(): "Empty result");
        }
    }
}
