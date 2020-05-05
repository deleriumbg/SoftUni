using System;
using System.Linq;

namespace Magic_Exchangeable_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Console.WriteLine(IsExchangeable(input[0], input[1]) ? "true" : "false");
        }

        private static bool IsExchangeable(string str1, string str2)
        {
            string word1 = new String(str1.Distinct().ToArray());
            string word2 = new String(str2.Distinct().ToArray());
            if (word1.Length == word2.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
