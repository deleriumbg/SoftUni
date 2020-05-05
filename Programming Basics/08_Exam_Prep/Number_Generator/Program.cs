using System;

namespace Number_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int special = int.Parse(Console.ReadLine());
            int control = int.Parse(Console.ReadLine());

            for (int i = M; i >= 1; i--)
            {
                for (int j = N; j >= 1; j--)
                {
                    for (int k = L; k >= 1; k--)
                    {
                        if (special >= control)
                        {
                            Console.WriteLine($"Yes! Control number was reached! Current special number is {special}.");
                            return;
                        }
                        if ((i * 100 + j * 10 + k) % 3 == 0)
                        {
                            special += 5;
                            continue;
                        }
                        if (k == 5)
                        {
                            special -= 2;
                            continue;
                        }
                        if (k % 2 == 0)
                        {
                            special *= 2;
                            continue;
                        }
                    }
                }
            }
            Console.WriteLine($"No! {special} is the last reached special number.");
        }
    }
}
