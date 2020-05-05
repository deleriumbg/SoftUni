using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            List<int> ladybugIndexes = Console.ReadLine().Split(new [] {' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x => x >= 0 && x < fieldSize).ToList();
            
            int[] ladybugs = new int[fieldSize];
            for (int i = 0; i < fieldSize; i++)
            {
                if (ladybugIndexes.Contains(i))
                {
                    ladybugs[i] = 1;
                }
                else
                {
                    ladybugs[i] = 0;
                }
            }
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split(' ');
                int ladybugIndex = int.Parse(commandArgs[0]);
                string direction = commandArgs[1];
                int flyLength = int.Parse(commandArgs[2]);

                if (ladybugIndex > fieldSize || ladybugIndex < 0 || ladybugs[ladybugIndex] == 0)
                {
                    command = Console.ReadLine();
                    continue;
                }

                ladybugs[ladybugIndex] = 0;
                switch (direction)
                {
                    case "right":
                        if (ladybugIndex + flyLength < fieldSize)
                        {
                            while (ladybugIndex + flyLength < fieldSize)
                            {
                                if (ladybugs[ladybugIndex + flyLength] == 0)
                                {
                                    ladybugs[ladybugIndex + flyLength] = 1;
                                    break;
                                }
                                ladybugIndex += flyLength;
                            }
                        }
                        break;
                    case "left":
                        if (ladybugIndex - flyLength >= 0)
                        {
                            while (ladybugIndex - flyLength >= 0)
                            {
                                if (ladybugs[ladybugIndex - flyLength] == 0)
                                {
                                    ladybugs[ladybugIndex - flyLength] = 1;
                                    break;
                                }
                                ladybugIndex -= flyLength;
                            }
                        }
                        break;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", ladybugs));
        }
    }
}
