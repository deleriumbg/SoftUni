using System;

namespace Ivanovis_Holiday
{
    class Program
    {
        static void Main(string[] args)
        {
            int nightsCount = int.Parse(Console.ReadLine());
            string destination = Console.ReadLine().ToLower();
            string transport = Console.ReadLine().ToLower();

            double hotelSum = 0;
            switch (destination)
            {
                case "miami":
                    if (nightsCount >= 1 && nightsCount <= 10)
                    {
                        hotelSum += nightsCount * (2 * 24.99 + 3 * 14.99);
                    }
                    else if (nightsCount >= 11 && nightsCount <= 15)
                    {
                        hotelSum += nightsCount * (2 * 22.99 + 3 * 11.99);
                    }
                    else if (nightsCount > 15)
                    {
                        hotelSum += nightsCount * (2 * 20 + 3 * 10);
                    }
                    break;
                case "canary islands":
                    if (nightsCount >= 1 && nightsCount <= 10)
                    {
                        hotelSum += nightsCount * (2 * 32.50 + 3 * 28.50);
                    }
                    else if (nightsCount >= 11 && nightsCount <= 15)
                    {
                        hotelSum += nightsCount * (2 * 30.50 + 3 * 25.60);
                    }
                    else if (nightsCount > 15)
                    {
                        hotelSum += nightsCount * (2 * 28 + 3 * 22);
                    }
                    break;
                case "philippines":
                    if (nightsCount >= 1 && nightsCount <= 10)
                    {
                        hotelSum += nightsCount * (2 * 42.99 + 3 * 39.99);
                    }
                    else if (nightsCount >= 11 && nightsCount <= 15)
                    {
                        hotelSum += nightsCount * (2 * 41 + 3 * 36);
                    }
                    else if (nightsCount > 15)
                    {
                        hotelSum += nightsCount * (2 * 38.50 + 3 * 32.40);
                    }
                    break;
            }
            hotelSum *= 1.25;
            double transportSum = 0;
            switch (transport)
            {
                case "train":
                    transportSum += 2 * 22.30 + 3 * 12.50;
                    break;
                case "bus":
                    transportSum += 2 * 45 + 3 * 37;
                    break;
                case "airplane":
                    transportSum += 2 * 90 + 3 * 68.50;
                    break;
            }
            Console.WriteLine($"{hotelSum + transportSum:f3}");
        }
    }
}
