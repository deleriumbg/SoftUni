using System;
using System.Linq;

namespace Remove_Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var evenOccurences = input.Where(x => input.Count(n => n == x) % 2 == 0);
            Console.WriteLine(string.Join(" ", evenOccurences));
        }
    }
}
