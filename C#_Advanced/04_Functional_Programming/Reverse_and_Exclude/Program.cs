using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();
            int divisor = int.Parse(Console.ReadLine());

            Func<int, bool> filter = x => x % divisor != 0;

            Console.WriteLine(string.Join(" ",numbers.Where(filter)));
        }
    }
}
