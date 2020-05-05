using System;
using System.Numerics;
using System.Text;

namespace Convert_From_Base_10_to_Base_N
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int system = int.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);
            StringBuilder result = new StringBuilder();
            BigInteger remainder = 0;
            while (number > 0)
            {
                remainder = number % system;
                result.Append(remainder);
                number /= system;
            }
            Console.WriteLine(ReverseString(result.ToString()));
        }

        public static string ReverseString(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }
    }
}
