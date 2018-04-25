using System;

namespace Illidan
{
    class Program
    {
        static void Main(string[] args)
        {
            int playersCount = int.Parse(Console.ReadLine());
            int playerPower = int.Parse(Console.ReadLine());
            int illidanHealth = int.Parse(Console.ReadLine());
            if (playersCount * playerPower >= illidanHealth)
            {
                Console.WriteLine($"Illidan has been slain! You defeated him with {(playersCount * playerPower) - illidanHealth} points.");
            }
            else
            {
                Console.WriteLine($"You are not prepared! You need {illidanHealth - (playersCount * playerPower)} more points.");
            }
        }
    }
}
