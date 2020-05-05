using System;
using System.Text.RegularExpressions;

namespace Use_Your_Chains_Buddy
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"<p>(.+?)<\/p>";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                string text = match.Groups[1].Value;
                string replaced = Regex.Replace(text, @"[\WA-Z]", " ");
                replaced = Regex.Replace(replaced, @"\s+", " ");

                foreach (var character in replaced)
                {
                    if (character >= 'a' && character <= 'm')
                    {
                        Console.Write((char)(character + 13));
                    }
                    else if (character >= 'n' && character <= 'z')
                    {
                        Console.Write((char)(character - 13));
                    }
                    else
                    {
                        Console.Write(character);
                    }
                }
            }
        }
    }
}
