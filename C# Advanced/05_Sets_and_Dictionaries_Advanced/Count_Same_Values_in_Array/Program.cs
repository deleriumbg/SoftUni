using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> occurrences = new Dictionary<double, int>();

            foreach (var num in numbers)
            {
                if (!occurrences.ContainsKey(num))
                {
                    occurrences.Add(num, 0);
                }

                occurrences[num]++;
            }

            foreach (var item in occurrences)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
