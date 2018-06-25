using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Over!")
            {
                List<int> verificationIndexes = new List<int>();

                int messageLength = int.Parse(Console.ReadLine());
                string pattern = @"^(\d+)([A-Za-z]+)([^A-Za-z]*)$";
                if (!Regex.IsMatch(input, pattern))
                {
                    continue;
                }
                Match match = Regex.Match(input, pattern);

                string message = match.Groups[2].Value;
                if (message.Length != messageLength)
                {
                    continue;
                }
                string firstNumber = match.Groups[1].Value;
                foreach (var symbol in firstNumber)
                {
                    verificationIndexes.Add(int.Parse(symbol.ToString()));
                }

                if (Regex.IsMatch(match.Groups[3].Value, "\\d+"))
                {
                    Match secondPart = Regex.Match(match.Groups[3].Value, "\\d+");
                    string secondNumber = secondPart.Value;
                    foreach (var symbol in secondNumber)
                    {
                        verificationIndexes.Add(int.Parse(symbol.ToString()));
                    }
                }
                StringBuilder result = new StringBuilder();
                result.Append($"{message} == ");
                foreach (var index in verificationIndexes)
                {
                    if (index < 0 || index >= message.Length)
                    {
                        result.Append(' ');
                    }
                    else
                    {
                        result.Append(message[index]);
                    }
                }
                Console.WriteLine(result.ToString());
            }
        }
    }
}
