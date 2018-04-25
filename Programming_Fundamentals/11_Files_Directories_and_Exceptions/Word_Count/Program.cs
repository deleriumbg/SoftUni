using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllText("words.txt").Split(' ');
            string text = File.ReadAllText("Input.txt").ToLower();
            File.Delete("Output.txt");
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (string word in words)
            {
                string pattern = $@"\b{word}\b";
                MatchCollection matches = Regex.Matches(text, pattern);
                result[word] = matches.Count;
            }
            StringBuilder output = new StringBuilder();
            foreach (var pair in result.OrderByDescending(x => x.Value))
            {
                output.AppendLine($"{pair.Key} - {pair.Value}");
            }
            File.AppendAllText("Output.txt", output.ToString());
        }
    }
}
