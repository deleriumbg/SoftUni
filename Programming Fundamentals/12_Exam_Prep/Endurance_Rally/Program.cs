using System;
using System.Linq;

namespace Endurance_Rally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] drivers = Console.ReadLine().Split(' ');
            double[] zones = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int[] checkpoints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            foreach (var driver in drivers)
            {
                double startingFuel = driver[0];
                for (int i = 0; i < zones.Length; i++)
                {
                    if (checkpoints.Contains(i))
                    {
                        startingFuel += zones[i];
                    }
                    else
                    {
                        startingFuel -= zones[i];
                        if (startingFuel <= 0)
                        {
                            Console.WriteLine($"{driver} - reached {i}");
                            break;
                        }
                    }
                }

                if (startingFuel > 0)
                {
                    Console.WriteLine($"{driver} - fuel left {startingFuel:f2}");
                } 
            }
        }
    }
}
