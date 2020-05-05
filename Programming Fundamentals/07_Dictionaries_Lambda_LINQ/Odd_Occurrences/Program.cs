using System;
using System.Collections.Generic;
using System.Linq;

namespace Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> oddOccurance = new Dictionary<string, int>();
            string[] input = Console.ReadLine().ToLower().Split(' ').ToArray();
            List<string> result = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (oddOccurance.ContainsKey(input[i]) == false)
                {
                    oddOccurance.Add(input[i], 1);
                }
                else
                {
                    oddOccurance[input[i]]++;
                }
            }
            foreach (var word in oddOccurance)
            {
                if (word.Value % 2 == 1)
                {
                    result.Add(word.Key);
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
