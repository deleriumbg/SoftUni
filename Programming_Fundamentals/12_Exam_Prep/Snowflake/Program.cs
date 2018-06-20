using System;
using System.Text.RegularExpressions;

namespace Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            string surfacePattern = @"^([^A-Za-z0-9]+)$";
            string mantlePattern = @"^([_\d]+)$";
            string corePattern = @"^([^A-Za-z0-9]+)([_\d]+)([A-Za-z]+)([_\d]+)([^A-Za-z0-9]+)$";
            int coreLength = 0;

            for (int i = 1; i <= 5; i++)
            {
                string input = Console.ReadLine();
                if (i == 1 || i == 5)
                {
                    CheckIfInvalid(input, surfacePattern);
                }
                else if (i == 2 || i == 4)
                {
                    CheckIfInvalid(input, mantlePattern);
                }
                else
                {
                    CheckIfInvalid(input, corePattern);
                    Match match = Regex.Match(input, corePattern);
                    coreLength = match.Groups[3].Value.Length;
                }
                
            }
            Console.WriteLine("Valid");
            Console.WriteLine(coreLength);
        }

        private static void CheckIfInvalid(string input, string pattern)
        {
            if (!Regex.IsMatch(input, pattern))
            {
                Console.WriteLine("Invalid");
                Environment.Exit(0);
            }
        }
    }
}
