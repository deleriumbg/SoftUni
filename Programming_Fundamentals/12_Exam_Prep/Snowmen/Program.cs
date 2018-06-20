using System;
using System.Linq;

namespace Snowmen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            while (sequence.Length > 1)
            {
                for (int currentIndex = 0; currentIndex < sequence.Length; currentIndex++)
                {
                    int attackerIndex = currentIndex;
                    int targetIndex = sequence[currentIndex] % sequence.Length;
                    int difference = Math.Abs(attackerIndex - targetIndex);

                    if (sequence.Where(x => x != -1).ToArray().Length == 1)
                    {
                        return;
                    }
                    if (difference == 0 && sequence[attackerIndex] != -1)
                    {
                        sequence[attackerIndex] = -1;
                        Console.WriteLine($"{attackerIndex} performed harakiri");
                    }
                    else if (difference % 2 == 0 && sequence[attackerIndex] != -1)
                    {
                        sequence[targetIndex] = -1;
                        Console.WriteLine($"{attackerIndex} x {targetIndex} -> {attackerIndex} wins");
                    }
                    else if (difference % 2 != 0 && sequence[attackerIndex] != -1)
                    {
                        sequence[attackerIndex] = -1;
                        Console.WriteLine($"{attackerIndex} x {targetIndex} -> {targetIndex} wins");
                    }
                }
                sequence = sequence.Where(x => x != -1).ToArray();
            }
        }
    }
}
