using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.2)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
