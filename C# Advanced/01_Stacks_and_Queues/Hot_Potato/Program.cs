using System;
using System.Collections.Generic;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split(' ');
            int toss = int.Parse(Console.ReadLine());
            Queue<string> players = new Queue<string>(kids);

            while (players.Count > 1)
            {
                for (int i = 0; i < toss - 1; i++)
                {
                    players.Enqueue(players.Dequeue());
                }
                Console.WriteLine($"Removed {players.Dequeue()}");
            }
            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
