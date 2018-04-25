using System;

namespace Aquapark
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            int hoursSpent = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine().ToLower();

            double pricePerHour = 0;
            switch (month)
            {
                case "march":
                case "april":
                case "may":
                    if (dayOrNight == "day")
                    {
                        pricePerHour = 10.5;
                    }
                    else if (dayOrNight == "night")
                    {
                        pricePerHour = 8.4;
                    }
                    break;
                case "june":
                case "july":
                case "august":
                    if (dayOrNight == "day")
                    {
                        pricePerHour = 12.6;
                    }
                    else if (dayOrNight == "night")
                    {
                        pricePerHour = 10.2;
                    }
                    break;
                default:
                    break;
            }
            if (peopleCount >= 4)
            {
                pricePerHour *= 0.9;
            }
            if (hoursSpent >= 5)
            {
                pricePerHour *= 0.5;
            }
            Console.WriteLine($"Price per person for one hour: {pricePerHour:f2}\r\nTotal cost of the visit: {(pricePerHour * hoursSpent) * peopleCount:f2}");
        }
    }
}
