using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Anonymous_Vox
{
    class Program
    {
        static void Main(string[] args)
        {
            string encodedText = Console.ReadLine();
            string placeholders = Console.ReadLine();
            string textPattern = @"([A-Za-z]+)(.*)(\1)";
            string placeholderPattern = @"{(.+?)}";

            List<string> placeholderValues = new List<string>();
            MatchCollection placeholderMatches = Regex.Matches(placeholders, placeholderPattern);
            foreach (Match match in placeholderMatches)
            {
                placeholderValues.Add(match.Groups[1].Value);
            }

            MatchCollection textMatches = Regex.Matches(encodedText, textPattern);
            int indexIterator = 0;
            foreach (Match match in textMatches)
            {
                string textToReplace = match.Groups[1].Value + placeholderValues[indexIterator] + match.Groups[3].Value;
                encodedText = encodedText.Replace(match.Value, textToReplace);
                indexIterator++;
            }

            Console.WriteLine(encodedText);
        }
    }
}
