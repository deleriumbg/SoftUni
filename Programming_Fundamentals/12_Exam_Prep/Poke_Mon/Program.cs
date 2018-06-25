using System;

namespace Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            decimal halfPower = (decimal)pokePower / 2;

            int count = 0;
            while (pokePower >= distance)
            {
                pokePower -= distance;
                count++;
                if (pokePower == halfPower)
                {
                    if (exhaustionFactor != 0)
                    {
                        pokePower /= exhaustionFactor;
                    }
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(count);
        }
    }
}
