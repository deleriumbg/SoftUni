using System;
using System.Text.RegularExpressions;

namespace Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            const string surfacePattern = @"^([^A-Za-z0-9]+)$";
            const string mantlePattern = @"^([_\d]+)$";
            const string corePattern = @"^([^A-Za-z0-9]+)([_\d]+)([A-Za-z]+)([_\d]+)([^A-Za-z0-9]+)$";
            int coreLength = 0;

            for (int i = 1; i <= 5; i++)
            {
                string input = Console.ReadLine();
                switch (i)
                {
                    case 1:
                    case 5:
                        CheckIfInvalid(input, surfacePattern);
                        break;
                    case 2:
                    case 4:
                        CheckIfInvalid(input, mantlePattern);
                        break;
                    default:
                        CheckIfInvalid(input, corePattern);
                        Match match = Regex.Match(input, corePattern);
                        coreLength = match.Groups[3].Value.Length;
                        break;
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
