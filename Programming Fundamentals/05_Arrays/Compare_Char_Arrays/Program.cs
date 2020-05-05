using System;
using System.Linq;

namespace Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] input2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            for (int i = 0; i < Math.Min(input1.Length, input2.Length); i++)
            {
                if (input1[i] > input2[i])
                {
                    Console.WriteLine(string.Join("", input2));
                    Console.WriteLine(string.Join("", input1));
                    return;
                }
                else if (input1[i] < input2[i])
                {
                    Console.WriteLine(string.Join("", input1));
                    Console.WriteLine(string.Join("", input2));
                    return;
                }
            }
            if (input1.Length >= input2.Length)
            {
                Console.WriteLine(string.Join("", input2));
                Console.WriteLine(string.Join("", input1));
            }
            else
            {
                Console.WriteLine(string.Join("", input1));
                Console.WriteLine(string.Join("", input2));
            }
        }
    }
}
