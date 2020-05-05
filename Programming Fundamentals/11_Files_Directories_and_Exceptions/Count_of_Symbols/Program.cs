using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Count_of_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = File.ReadAllText("Input.txt").ToCharArray();
            File.Delete("Output.txt");
            Dictionary<char, int> occurancies = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (occurancies.ContainsKey(input[i]) == false)
                {
                    occurancies[input[i]] = 1;
                }
                else
                {
                    occurancies[input[i]]++;
                }
            }
            foreach (var letter in occurancies.OrderByDescending(x => x.Value))
            {
                string result = $"{letter.Key} -> {letter.Value}";
                File.AppendAllText("Output.txt", result + Environment.NewLine);
            }
        }
    }
}
