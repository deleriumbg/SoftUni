using System;
using System.Text.RegularExpressions;

namespace Replace_a_Tag
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                string pattern1 = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
                string pattern2 = @"[URL href=$1]$2[/URL]";
                string replaced = Regex.Replace(input, pattern1, pattern2);
                Console.WriteLine(replaced);
                input = Console.ReadLine();
            }
        }
    }
}
