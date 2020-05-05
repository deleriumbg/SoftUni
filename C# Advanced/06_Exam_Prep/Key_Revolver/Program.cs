using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver 
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunSize = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>();
            Stack<int> bullets = new Stack<int>();

            foreach (var bullet in bulletsInput)
            {
                bullets.Push(bullet);
            }

            foreach (var currentLock in locksInput)
            {
                locks.Enqueue(currentLock);
            }

            int bulletCounter = 0;

            while (true)
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                bulletCounter++;

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletCounter == gunSize && bullets.Count > 0)
                {
                    bulletCounter = 0;
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0)
                {
                    int moneyEarned = intelligence - (bulletsInput.Length - bullets.Count) * bulletPrice;
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
                    break;
                }
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
            }
        }
    }
}
