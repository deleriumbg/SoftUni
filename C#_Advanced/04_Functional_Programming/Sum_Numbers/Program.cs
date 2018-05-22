using System;
using System.Linq;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
