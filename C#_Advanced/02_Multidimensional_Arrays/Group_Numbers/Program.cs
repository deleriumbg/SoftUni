using System;
using System.Collections.Generic;
using System.Linq;

namespace Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> zeroDivider = new List<int>();
            List<int> oneDivider = new List<int>();
            List<int> twoDivider = new List<int>();
            foreach (var number in input)
            {
                if (Math.Abs(number) % 3 == 0)
                {
                    zeroDivider.Add(number);
                }
                else if (Math.Abs(number) % 3 == 1)
                {
                    oneDivider.Add(number);
                }
                else if (Math.Abs(number) % 3 == 2)
                {
                    twoDivider.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ", zeroDivider));
            Console.WriteLine(string.Join(" ", oneDivider));
            Console.WriteLine(string.Join(" ", twoDivider));
        }
    }
}
