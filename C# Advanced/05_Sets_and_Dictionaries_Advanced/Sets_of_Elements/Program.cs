using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setLengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            for (int i = 0; i < setLengths[0]; i++)
            {
                list1.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setLengths[1]; i++)
            {
                list2.Add(int.Parse(Console.ReadLine()));
            }

            var intersect = list1.Intersect(list2);

            foreach (int value in intersect)
            {
                Console.Write($"{value} ");
            }
        }
    }
}
