using System;

namespace Melrah_Shake
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            string pattern = Console.ReadLine();

            int firstMatch = sequence.IndexOf(pattern);
            int lastMatch = sequence.LastIndexOf(pattern);

            while (pattern.Length > 0 && (firstMatch >= 0 && lastMatch > firstMatch))
            {
                Console.WriteLine("Shaked it.");
                int indexAfterFirstMatch = firstMatch + pattern.Length;
                int indexBeforeLastMatch = lastMatch - indexAfterFirstMatch;

                sequence = sequence.Substring(0, firstMatch) + sequence.Substring(indexAfterFirstMatch, indexBeforeLastMatch)
                       + sequence.Substring(lastMatch + pattern.Length);

                pattern = pattern.Remove(pattern.Length / 2, 1);
                firstMatch = sequence.IndexOf(pattern);
                lastMatch = sequence.LastIndexOf(pattern);
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(sequence);
        }
    }
}
