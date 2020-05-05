using System;

namespace CSGO
{
    class Program
    {
        static void Main(string[] args)
        {
            int itemsCount = int.Parse(Console.ReadLine());
            int money = int.Parse(Console.ReadLine());
            for (int i = 0; i < itemsCount; i++)
            {
                if (itemsCount > 7)
                {
                    Console.WriteLine("Sorry, you can't carry so many things!");
                    return;
                }
                string weapon = Console.ReadLine();
                switch (weapon)
                {
                    case "ak47":
                        money -= 2700;
                        break;
                    case "awp":
                        money -= 4750;
                        break;
                    case "sg553":
                        money -= 3500;
                        break;
                    case "grenade":
                        money -= 300;
                        break;
                    case "flash":
                        money -= 250;
                        break;
                    case "glock":
                        money -= 500;
                        break;
                    case "bazooka":
                        money -= 5600;
                        break;
                }
            }
            if (money >= 0)
            {
                Console.WriteLine($"You bought all {itemsCount} items! Get to work and defeat the bomb!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(money)} more money.");
            }
        }
    }
}
