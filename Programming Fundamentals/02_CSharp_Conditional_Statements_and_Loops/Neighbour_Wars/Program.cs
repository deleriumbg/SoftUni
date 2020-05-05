using System;

namespace Neighbour_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());
            int peshoHealth = 100;
            int goshoHealth = 100;
            int roundCounter = 0;

            while (peshoHealth > 0 && goshoHealth > 0)
            {
                roundCounter++;
                if (roundCounter % 2 == 1)
                {
                    goshoHealth -= peshoDamage;
                    if (goshoHealth > 0)
                    {
                        Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoHealth} health.");
                    }
                    else
                    {
                        break;
                    }
                }
                if (roundCounter % 2 == 0)
                {
                    peshoHealth -= goshoDamage;
                    if (peshoHealth > 0)
                    {
                        Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoHealth} health.");
                    }
                    else
                    {
                        break;
                    }
                }
                if (roundCounter % 3 == 0)
                {
                    peshoHealth += 10;
                    goshoHealth += 10;
                }
            }
            if (peshoHealth <= 0)
            {
                Console.WriteLine($"Gosho won in {roundCounter}th round.");
            }
            if (goshoHealth <= 0)
            {
                Console.WriteLine($"Pesho won in {roundCounter}th round.");
            }
        }
    }
}
