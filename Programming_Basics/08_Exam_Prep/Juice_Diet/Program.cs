using System;

namespace Juice_Diet
{
    class Program
    {
        static void Main(string[] args)
        {
            int raspberryMax = int.Parse(Console.ReadLine());
            int strawberryMax = int.Parse(Console.ReadLine());
            int cherryMax = int.Parse(Console.ReadLine());
            int juiceAllowed = int.Parse(Console.ReadLine());

            double juiceMax = 0;
            int raspberry = 0;
            int strawberry = 0;
            int cherry = 0;
            for (int i = 0; i <= cherryMax; i++)
            {
                for (int j = 0; j <= strawberryMax; j++)
                {
                    for (int k = 0; k <= raspberryMax; k++)
                    {
                        double currentJuice = 15 * i + 7.5 * j + 4.5 * k;
                        if (currentJuice <= juiceAllowed)
                        {
                            if (currentJuice >= juiceMax)
                            {
                                juiceMax = currentJuice;
                                cherry = i;
                                strawberry = j;
                                raspberry = k;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"{raspberry} Raspberries, {strawberry} Strawberries, {cherry} Cherries. Juice: {juiceMax} ml.");
        }
    }
}
