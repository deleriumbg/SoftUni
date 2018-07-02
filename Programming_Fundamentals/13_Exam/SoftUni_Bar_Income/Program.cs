using System;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income 
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalIncome = 0.0;

            while (input != "end of shift")
            {
                string pattern = @"%([A-Z][a-z]+)%[^|$%.]*?<([\w]+)>[^|$%.]*?\|([\d]+)\|[^|$%.]*?(-*[0-9,\.]+)\$";
                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    string customerName = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int validCount = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);
                    Console.WriteLine($"{customerName}: {product} - {validCount * price:f2}");
                    totalIncome += validCount * price;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
