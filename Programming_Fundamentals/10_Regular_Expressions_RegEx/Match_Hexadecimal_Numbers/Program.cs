using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Match_Hexadecimal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b([0x]*)([0-9A-F]+)\b";
            MatchCollection matches = Regex.Matches(input, pattern);
            string[] result = matches.Cast<Match>().Select(x => x.Value).ToArray();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
