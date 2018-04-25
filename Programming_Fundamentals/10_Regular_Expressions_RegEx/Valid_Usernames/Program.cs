using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string pattern = @"\b([A-Za-z]{1}[\w+]{2,24})\b";
            List<string> matches = new List<string>();
            foreach (string word in input)
            {
                Match match = Regex.Match(word, pattern);
                if (match.Length > 0)
                {
                    matches.Add(match.ToString());
                }
            }
            int count = 0;
            int maxCount = 0;
            int indexMax = 0;
            for (int i = 0; i < matches.Count - 1; i++)
            {
                count = matches[i].Length + matches[i + 1].Length;
                if (maxCount < count)
                {
                    maxCount = count;
                    indexMax = i;
                }
            }
            Console.WriteLine(matches[indexMax]);
            Console.WriteLine(matches[indexMax + 1]);
        }
    }
}
