using System;

namespace Ivanovis_Family
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double firstPresent = double.Parse(Console.ReadLine());
            double secondPresent = double.Parse(Console.ReadLine());
            double thirdPresent = double.Parse(Console.ReadLine());

            double totalPresents = firstPresent + secondPresent + thirdPresent;
            Console.WriteLine($"{( budget - totalPresents) * 0.90:f2}");
        }
    }
}
