using System;

namespace Solar_System
{
    class Program
    {
        static void Main(string[] args)
        {
            string planet = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double distance = 0;
            double travellingTime = days;
            bool isInvalid = false;
            switch (planet)
            {
                case "Mercury":
                    if (days > 7)
                    {
                        isInvalid = true;
                        Console.WriteLine("Invalid number of days!");
                    }
                    else
                    {
                        distance += 2 * 0.61;
                        travellingTime += 2 * (226 * 0.61);
                    }
                    break;
                case "Venus":
                    if (days > 14)
                    {
                        isInvalid = true;
                        Console.WriteLine("Invalid number of days!");
                    }
                    else
                    {
                        distance += 2 * 0.28;
                        travellingTime += 2 * (226 * 0.28);
                    }
                    break;
                case "Mars":
                    if (days > 20)
                    {
                        isInvalid = true;
                        Console.WriteLine("Invalid number of days!");
                    }
                    else
                    {
                        distance += 2 * 0.52;
                        travellingTime += 2 * (226 * 0.52);
                    }
                    break;
                case "Jupiter":
                    if (days > 5)
                    {
                        isInvalid = true;
                        Console.WriteLine("Invalid number of days!");
                    }
                    else
                    {
                        distance += 2 * 4.2;
                        travellingTime += 2 * (226 * 4.2);
                    }
                    break;
                case "Saturn":
                    if (days > 3)
                    {
                        isInvalid = true;
                        Console.WriteLine("Invalid number of days!");
                    }
                    else
                    {
                        distance += 2 * 8.52;
                        travellingTime += 2 * (226 * 8.52);
                    }
                    break;
                case "Uranus":
                    if (days > 3)
                    {
                        isInvalid = true;
                        Console.WriteLine("Invalid number of days!");
                    }
                    else
                    {
                        distance += 2 * 18.21;
                        travellingTime += 2 * (226 * 18.21);
                    }
                    break;
                case "Neptune":
                    if (days > 2)
                    {
                        isInvalid = true;
                        Console.WriteLine("Invalid number of days!");
                    }
                    else
                    {
                        distance += 2 * 29.09;
                        travellingTime += 2 * (226 * 29.09);
                    }
                    break;
                default:
                    isInvalid = true;
                    Console.WriteLine("Invalid planet name!");
                    break;
            }
            if (!isInvalid)
            {
                Console.WriteLine($"Distance: {distance:f2}\r\nTotal number of days: {travellingTime:f2}");
            }
        }
    }
}
