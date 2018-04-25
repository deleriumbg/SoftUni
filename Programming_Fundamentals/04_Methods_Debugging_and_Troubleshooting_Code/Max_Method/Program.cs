using System;

namespace Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int result = GetMax(GetMax(a, b), c);
            Console.WriteLine(result);
        }

        static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
    }
}
