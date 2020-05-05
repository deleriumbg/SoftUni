using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Camera_View
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int skip = numbers[0];
            int take = numbers[1];
            string text = Console.ReadLine();
            string pattern = @"\|<(\w{" + skip + @"})(?<result>[\w]{0," + take + @"})";
            MatchCollection matches = Regex.Matches(text, pattern);
            string[] result = matches.Cast<Match>().Select(x => x.Groups["result"].Value).ToArray();
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
