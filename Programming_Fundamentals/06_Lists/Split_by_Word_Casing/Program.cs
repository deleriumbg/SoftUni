using System;
using System.Collections.Generic;
using System.Linq;

namespace Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> lowerCase = new List<string>();
            List<string> upperCase = new List<string>();
            List<string> mixedCase = new List<string>();
            int lowerCounter = 0;
            int upperCounter = 0;

            for (int i = 0; i < input.Count; i++)
            {
                char[] word = input[i].ToCharArray();
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j] >= 'a' && word[j] <= 'z')
                    {
                        lowerCounter++;
                    }
                    else if (word[j] >= 'A' && word[j] <= 'Z')
                    {
                        upperCounter++;
                    }
                }
                if (lowerCounter == word.Length)
                {
                    lowerCase.Add(input[i]);
                }
                else if (upperCounter == word.Length)
                {
                    upperCase.Add(input[i]);
                }
                else
                {
                    mixedCase.Add(input[i]);
                }
                lowerCounter = 0;
                upperCounter = 0;
            }
            Console.WriteLine("Lower-case: " + string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: " + string.Join(", ", upperCase));
        }
    }
}
