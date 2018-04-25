using System;
using System.Text.RegularExpressions;

namespace Extract_Sentences_by_Keyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string substring = Console.ReadLine();
            string[] input = Console.ReadLine().Split(new char[] { '.', '!', '?' });
            string pattern = $@"\b{substring}\b";
            foreach (var sentence in input)
            {
                if (Regex.IsMatch(sentence, pattern))
                {
                    Console.WriteLine(sentence.Trim());
                } 
            }
        }
    }
}
