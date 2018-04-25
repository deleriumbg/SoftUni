using System;

namespace Test_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 0;

            for (int i = N; i >= 1; i--)
            {
                for (int j = 1; j <= M; j++)
                {
                    if (sum <= max)
                    {
                        sum += 3 * (i * j);
                        counter++;
                    }
                    else
                    {
                        break;
                    } 
                }
            }
            if (sum >= max)
            {
                Console.WriteLine($"{counter} combinations\r\nSum: {sum} >= {max}");
            }
            else
            {
                Console.WriteLine($"{counter} combinations\r\nSum: {sum}");
            }
        }
    }
}
