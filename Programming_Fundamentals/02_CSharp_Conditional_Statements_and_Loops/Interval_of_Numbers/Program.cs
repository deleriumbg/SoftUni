using System;

namespace Interval_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            for (int i = Math.Min(a, b); i <= Math.Max(a, b); i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
