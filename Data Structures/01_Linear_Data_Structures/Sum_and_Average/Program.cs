using System;
using System.Linq;

namespace Sum_and_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            if (input.Count == 0)
            {
                input.Add(default(int));
            }
            Console.WriteLine($"Sum={input.Sum()}; Average={input.Average():f2}");
        }
    }
}
