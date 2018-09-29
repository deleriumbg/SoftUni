using System;
using System.Collections.Generic;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            string input = Console.ReadLine();
            foreach (var letter in input)
            {
                if (!symbols.ContainsKey(letter))
                {
                    symbols.Add(letter, 0);
                }

                symbols[letter]++;
            }

            foreach (var letter in symbols)
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
