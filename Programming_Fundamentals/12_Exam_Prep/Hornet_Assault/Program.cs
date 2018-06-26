using System;
using System.Collections.Generic;
using System.Linq;

namespace Hornet_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            List<long> hornets = Console.ReadLine().Split(' ').Select(long.Parse).ToList();          

            for (int currentBeehive = 0; currentBeehive < beehives.Count; currentBeehive++)
            {
                long hornetsSum = hornets.Sum();
                if (hornetsSum > beehives[currentBeehive] )
                {
                    beehives[currentBeehive] = 0;
                }
                else
                {
                    beehives[currentBeehive] -= hornetsSum;
                    if (beehives[currentBeehive] < 0)
                    {
                        beehives[currentBeehive] = 0;
                    }

                    if (hornets.Count > 0)
                    {
                        hornets.RemoveAt(0);
                    }
                    else
                    {
                        break;
                    } 
                }
            }

            beehives = beehives.Where(x => x > 0).ToList();
            if (beehives.Count > 0)
            {
                Console.WriteLine(string.Join(" ", beehives));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
