using System;

namespace Final_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int dancers = int.Parse(Console.ReadLine());
            double points = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string location = Console.ReadLine();

            double award = dancers * points;
            if (location == "Abroad")
            {
                award *= 1.5;
            }
            switch (location)
            {
                case "Bulgaria":
                    if (season == "summer")
                    {
                        award *= 0.95;
                    }
                    else if (season == "winter")
                    {
                        award *= 0.92;
                    }
                    break;
                case "Abroad":
                    if (season == "summer")
                    {
                        award *= 0.90;
                    }
                    else if (season == "winter")
                    {
                        award *= 0.85;
                    }
                    break;
            }
            double charity = award * 0.75;
            double moneyPerDancer = (award * 0.25) / dancers;
            Console.WriteLine($"Charity - {charity:f2}\r\nMoney per dancer - {moneyPerDancer:f2}");
        }
    }
}
