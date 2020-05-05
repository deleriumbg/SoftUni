using System;

namespace Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int oneLev = int.Parse(Console.ReadLine());
            int twoLev = int.Parse(Console.ReadLine());
            int fiveLev = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i <= oneLev; i++)
            {
                for (int j = 0; j <= twoLev; j++)
                {
                    for (int k = 0; k <= fiveLev; k++)
                    {
                        if (1 * i + 2 * j + 5 * k == sum)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
