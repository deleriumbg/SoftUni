using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Hornet_Comm
{
    class Program
    {
        static void Main(string[] args)
        {
            //If the first query consists only of digits and the second one consists of digits and / or letters, it is a private message.
            //If the first query consists of anything but digits, and the second one consists of letters and / or digits, it is a broadcast.
            string privateMessagePattern = @"^([\d]+) <-> ([A-Za-z0-9]+)$";
            string broadcastMessagePattern = @"^([^\d]+) <-> ([A-Za-z0-9]+)$";

            List<Tuple<string, string>> messages = new List<Tuple<string, string>>();
            List<Tuple<string, string>> broadcasts = new List<Tuple<string, string>>();

            string input = Console.ReadLine();
            while (input != "Hornet is Green")
            {
                if (!Regex.IsMatch(input, privateMessagePattern) && !Regex.IsMatch(input, broadcastMessagePattern))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (Regex.IsMatch(input, privateMessagePattern))
                {
                    Match match = Regex.Match(input, privateMessagePattern);
                    string recipientCode = match.Groups[1].Value;
                    recipientCode = Reverse(recipientCode);
                    string message = match.Groups[2].Value;
                    messages.Add(new Tuple<string, string>(recipientCode, message));
                }
                else if (Regex.IsMatch(input, broadcastMessagePattern))
                {
                    Match match = Regex.Match(input, broadcastMessagePattern);
                    string message = match.Groups[1].Value;
                    string frequency = match.Groups[2].Value;

                    StringBuilder result = new StringBuilder();
                    foreach (var symbol in frequency)
                    {
                        if (char.IsUpper(symbol))
                        {
                            result.Append(symbol.ToString().ToLower());
                        }
                        else if (char.IsLower(symbol))
                        {
                            result.Append(symbol.ToString().ToUpper());
                        }
                        else
                        {
                            result.Append(symbol.ToString());
                        }
                    }
                    broadcasts.Add(new Tuple<string, string>(result.ToString(), message));
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count > 0)
            {
                foreach (var pair in broadcasts)
                {
                    Console.WriteLine($"{pair.Item1} -> {pair.Item2}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            
            Console.WriteLine("Messages:");
            if (messages.Count > 0)
            {
                foreach (var pair in messages)
                {
                    Console.WriteLine($"{pair.Item1} -> {pair.Item2}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }

        public static string Reverse(string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
