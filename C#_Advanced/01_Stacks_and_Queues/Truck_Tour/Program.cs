using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());
            Queue<long[]> queue = new Queue<long[]>();

            for (int i = 0; i < pumps; i++)
            {
                long[] pumpInfo = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                queue.Enqueue(pumpInfo);
            }

            for (int currentStart = 0; currentStart < pumps - 1; currentStart++)
            {
                long fuel = 0;
                bool isSolution = true;

                for (int pumpsPassed = 0; pumpsPassed < pumps; pumpsPassed++)
                {
                    long[] currentPump = queue.Dequeue();
                    long petrol = currentPump[0];
                    long distance = currentPump[1];
                    queue.Enqueue(currentPump);
                    fuel += petrol - distance;
                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        isSolution = false;
                        break;
                    }
                }
                if (isSolution)
                {
                    Console.WriteLine(currentStart);
                    return;
                }
            }
        }
    }
}
