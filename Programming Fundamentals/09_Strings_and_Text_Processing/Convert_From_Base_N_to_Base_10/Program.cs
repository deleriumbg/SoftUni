using System;
using System.Numerics;
using System.Text;

namespace Convert_From_Base_N_to_Base_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int system = int.Parse(input[0]);
            string number = input[1];
            BigInteger sum = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                sum += (number[i] - 48) * BigInteger.Pow(system, number.Length - 1 - i);
            }
            Console.WriteLine(sum);
        }
    }
}
