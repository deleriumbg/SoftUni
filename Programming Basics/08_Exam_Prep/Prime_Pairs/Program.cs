using System;

namespace Prime_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int startFirst = int.Parse(Console.ReadLine());
            int startSecond = int.Parse(Console.ReadLine());
            int firstAmount = int.Parse(Console.ReadLine());
            int secondAmount = int.Parse(Console.ReadLine());
            int endFirst = startFirst + firstAmount;
            int endSecond = startSecond + secondAmount;
            for (int i = startFirst; i <= endFirst; i++)
            {
                for (int j = startSecond; j <= endSecond; j++)
                {
                    if (IsPrime(i) && IsPrime(j))
                    {
                        Console.WriteLine($"{i}{j}");
                    }
                }
            }
        }

        static bool IsPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
