using System;
using System.Linq;

namespace Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            Random random = new Random();
            Console.WriteLine(string.Join ("\n", input.OrderBy(x => random.Next())));
        }
    }
}
