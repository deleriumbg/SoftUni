using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int totalPieces = width * length;
            string input = Console.ReadLine();
            int pieces = 0;
            while (input != "STOP")
            {
                pieces = int.Parse(input);
                totalPieces -= pieces;
                if (totalPieces < 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(totalPieces)} pieces more.");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{totalPieces} pieces are left.");
        }
    }
}
