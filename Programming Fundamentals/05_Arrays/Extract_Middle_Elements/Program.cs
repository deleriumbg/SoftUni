using System;
using System.Linq;

namespace Extract_Middle_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (input.Length == 1)
            {
                Console.WriteLine(input[0]);
            }
            else if (input.Length % 2 == 0)
            {
                Console.WriteLine(input[(input.Length / 2) - 1] + " " + input[input.Length / 2]);
            }
            else if (input.Length % 2 != 0)
            {
                Console.WriteLine(input[(input.Length / 2) - 1] + " " + input[input.Length / 2] + " " + input[(input.Length / 2) + 1]);
            }
        }
    }
}
