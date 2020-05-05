using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(^|(?<=\s))[A-Za-z0-9]+[-._\w+]*@[A-Za-z0-9]+[-._\w+]*\.\w+";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match item in matches)
            {
                Console.WriteLine(item);
            }
        }
    }
}
