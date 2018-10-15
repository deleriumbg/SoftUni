using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Data_Transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"s:(?<sender>[^;]+);r:(?<receiver>[^;]+);m--\""(?<message>[A-Za-z ]+)\""";

            int numberOfInputs = int.Parse(Console.ReadLine());
            int totalData = 0;

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();
                
                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    string sender = match.Groups["sender"].Value;
                    string reciever = match.Groups["receiver"].Value;
                    string message = match.Groups["message"].Value;

                    StringBuilder validSender = new StringBuilder();
                    foreach (var symbol in sender)
                    {
                        if (char.IsDigit(symbol))
                        {
                            totalData += int.Parse(symbol.ToString());
                        }

                        if (IsEnglishLetter(symbol))
                        {
                            validSender.Append(symbol);
                        }
                    }

                    StringBuilder validReciever = new StringBuilder();
                    foreach (var symbol in reciever)
                    {
                        if (char.IsDigit(symbol))
                        {
                            totalData += int.Parse(symbol.ToString());
                        }

                        if (IsEnglishLetter(symbol))
                        {
                            validReciever.Append(symbol);
                        }
                    }

                    Console.WriteLine($@"{validSender} says ""{message}"" to {validReciever}");
                }
                
            }

            Console.WriteLine($"Total data transferred: {totalData}MB");
        }

        private static bool IsEnglishLetter(char symbol)
        {
            return (symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z') || symbol == ' ';
        }
    }
}
