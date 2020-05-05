using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> result = numbers.Where(x => x > numbers.Average()).OrderByDescending(x => x).Take(5).ToList();
            Console.WriteLine(result.Count > 0 ? string.Join(" ", result) : "No");
        }
    }
}
