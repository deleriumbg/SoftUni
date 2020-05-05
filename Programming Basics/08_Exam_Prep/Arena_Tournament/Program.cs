using System;

namespace Arena_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            string arenaName = Console.ReadLine();
            string day = Console.ReadLine();
            string itemType = Console.ReadLine();

            double priceAllItems = 0;
            switch (itemType)
            {
                case "Poor":
                    priceAllItems = 7000;
                    break;
                case "Normal":
                    priceAllItems = 14000;
                    break;
                case "Legendary":
                    priceAllItems = 21000;
                    break;
            }
            switch (day)
            {
                case "Monday":
                case "Wednesday":
                    if (arenaName == "Nagrand")
                    {
                        priceAllItems *= 0.95;
                    }
                    break;
                case "Tuesday":
                case "Thursday":
                    if (arenaName == "Gurubashi")
                    {
                        priceAllItems *= 0.90;
                    }
                    break;
                case "Friday":
                case "Saturday":
                    if (arenaName == "Dire Maul")
                    {
                        priceAllItems *= 0.93;
                    }
                    break;
                default:
                    break;
            }

            double pricePerItem = priceAllItems / 5;
            int itemsBought = (int)Math.Floor(points / pricePerItem);
            if (itemsBought > 5)
            {
                itemsBought = 5;
            }
            double pointsLeft = points - (itemsBought * pricePerItem);
            Console.WriteLine($"Items bought: {itemsBought}");
            Console.WriteLine($"Arena points left: {pointsLeft}");
            if (points >= priceAllItems)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Failure!");
            }
        }
    }
}
