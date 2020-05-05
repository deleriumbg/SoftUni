using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int cources = (int)Math.Ceiling(1.0 * peopleCount / capacity);
            Console.WriteLine(cources);
        }
    }
}
