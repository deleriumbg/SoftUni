using System;

namespace Battles
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int maxBattles = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 1; i <= first; i++)
            {
                for (int j = 1; j <= second; j++)
                {
                    counter++;
                    Console.Write($"({i} <-> {j}) ");
                    if (counter == maxBattles)
                    {
                        return;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
