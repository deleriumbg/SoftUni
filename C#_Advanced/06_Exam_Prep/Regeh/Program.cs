using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\[[\w]+<(\d+)REGEH(\d+)>[\w]+\]";
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);
            List<int> indexes = new List<int>();

            foreach (Match match in matches)
            {
                indexes.Add(int.Parse(match.Groups[1].Value));
                indexes.Add(int.Parse(match.Groups[2].Value));
            }
             
            int currentIndex = 0;
            foreach (var index in indexes)
            {
                currentIndex += index;
                Console.Write(input[currentIndex % (input.Length - 1)]);
            }
            Console.WriteLine();
        }
    }
}
