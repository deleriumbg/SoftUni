using System;
using System.Linq;

namespace Cubics_Rube
{
    class Program
    {
        static void Main(string[] args)
        {
            int cubeSize = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int affectedCellsCount = 0;
            long affectedCellsSum = 0;

            while (command != "Analyze")
            {
                int[] coordinates = command.Split().Select(int.Parse).ToArray();
                if (IsInside(cubeSize, coordinates[0], coordinates[1], coordinates[2]))
                {
                    if (coordinates[3] != 0)
                    {
                        affectedCellsSum += coordinates[3];
                        affectedCellsCount++;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(affectedCellsSum);
            Console.WriteLine(Math.Pow(cubeSize, 3) - affectedCellsCount);
        }

        private static bool IsInside(int cubeSize, int x, int y, int z)
        {
            return x >= 0 && x < cubeSize && y >= 0 && y < cubeSize && z >= 0 && z < cubeSize;
        }
    }
}
