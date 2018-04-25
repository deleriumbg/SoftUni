using System;
using System.Linq;

namespace Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            string[] reversed = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                reversed[0 + i] = input[input.Length - 1 - i];
            }
            Console.WriteLine(string.Join(" ", reversed));
        }
    }
}

// Reverse by char:
//static string Reverse(string s)
//{
//    char[] charArray = s.ToCharArray();
//    Array.Reverse(charArray);
//    return new string(charArray);
//}
