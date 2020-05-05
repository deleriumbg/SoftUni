using System;

namespace Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());
            int ascii = Convert.ToInt32(input);
            if (ascii >= 48 && ascii <= 57)
            {
                Console.WriteLine("digit");
            }
            else if (ascii == 97 || ascii == 101 || ascii == 105 || ascii == 111 || ascii == 117 || ascii == 121)
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
