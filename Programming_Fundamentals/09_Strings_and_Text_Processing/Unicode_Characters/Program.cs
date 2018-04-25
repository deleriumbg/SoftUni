using System;

namespace Unicode_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            foreach (var character in input)
            {
                Console.Write(GetEscapeSequence(character));
            }

            string GetEscapeSequence(char c)
            {
                return "\\u" + ((int)c).ToString("x4");
            }
        }
    }
}
