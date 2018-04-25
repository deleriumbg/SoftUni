using System;

namespace Santas_Holiday
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine()) - 1;
            string roomType = Console.ReadLine();
            string feedback = Console.ReadLine();

            double totalMoney = 0;
            switch (roomType)
            {
                case "room for one person":
                    totalMoney += days * 18;
                    break;
                case "apartment":
                    if (days < 10)
                    {
                        totalMoney += (days * 25) * 0.70;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        totalMoney += (days * 25) * 0.65;
                    }
                    else
                    {
                        totalMoney += (days * 25) * 0.50;
                    }
                    break;
                case "president apartment":
                    if (days < 10)
                    {
                        totalMoney += (days * 35) * 0.90;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        totalMoney += (days * 35) * 0.85;
                    }
                    else
                    {
                        totalMoney += (days * 35) * 0.80;
                    }
                    break;
            }
            if (feedback == "positive")
            {
                totalMoney *= 1.25;
            }
            else if (feedback == "negative")
            {
                totalMoney *= 0.90;
            }
            Console.WriteLine($"{totalMoney:f2}");
        }
    }
}
