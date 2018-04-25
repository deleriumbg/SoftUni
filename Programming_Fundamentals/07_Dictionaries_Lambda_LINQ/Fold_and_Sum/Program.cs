using System;
using System.Collections.Generic;
using System.Linq;

namespace Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            int size = input.Count / 4;
            List<int> topLeft = new List<int>();
            List<int> topRight = new List<int>();
            List<int> top = new List<int>();
            List<int> bottom = new List<int>();
            topLeft.AddRange(input.Take(size));
            topLeft.Reverse();
            input.Reverse();
            topRight.AddRange(input.Take(size));
            input.Reverse();
            bottom.AddRange(input.Skip(size).Take(size * 2));
            top.AddRange(topLeft.Concat(topRight));

            var sum = top.Select((x, index) => x + bottom[index]);
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
