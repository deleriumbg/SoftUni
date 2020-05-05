using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            StringBuilder input = new StringBuilder();

            for (int i = 0; i < numberOfRows; i++)
            {
                input.Append(Console.ReadLine());
            }

            string pattern = @"{[^\{\}\[\]]+}|\[[^\{\}\[\]]+]";
            MatchCollection matches = Regex.Matches(input.ToString(), pattern);

            List<string> cryptoBlocks = new List<string>();
            foreach (Match match in matches)
            {
                cryptoBlocks.Add(match.ToString());
            }

            string numbersPattern = "[0-9]{3}";
            StringBuilder result = new StringBuilder();

            foreach (var block in cryptoBlocks)
            {
                List<int> numbers = new List<int>();
                MatchCollection numberMatches = Regex.Matches(block, numbersPattern);

                foreach (Match match in numberMatches)
                {
                    numbers.Add(int.Parse(match.ToString()));
                }
                
                numbers = numbers.Select(x => x - block.Length).ToList();

                foreach (var num in numbers)
                {
                    result.Append((char) num);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
