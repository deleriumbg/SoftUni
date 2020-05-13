using System;
using System.Linq;

namespace Count_of_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            input
                .Distinct()
                .Select(n => new
                {
                    Number = n,
                    Count = input.Count(e => e == n)
                })
                .OrderBy(n => n.Number)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n.Number} -> {n.Count} times"));
        }
    }
}
