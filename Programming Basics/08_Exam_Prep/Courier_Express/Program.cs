using System;

namespace Courier_Express
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string serviceType = Console.ReadLine();
            int distance = int.Parse(Console.ReadLine());

            double deliveryPrice = 0;
            switch (serviceType)
            {
                case "standard":
                    if (weight < 1)
                    {
                        deliveryPrice = distance * 0.03;
                    }
                    else if (weight >= 1 && weight <= 10)
                    {
                        deliveryPrice = distance * 0.05;
                    }
                    else if (weight > 10 && weight <= 40)
                    {
                        deliveryPrice = distance * 0.1;
                    }
                    else if (weight > 40 && weight <= 90)
                    {
                        deliveryPrice = distance * 0.15;
                    }
                    else if (weight > 90 && weight <= 150)
                    {
                        deliveryPrice = distance * 0.2;
                    }
                    break;
                case "express":
                    if (weight < 1)
                    {
                        deliveryPrice = distance * 0.03 + weight * distance * (0.8 * 0.03);
                    }
                    else if (weight >= 1 && weight <= 10)
                    {
                        deliveryPrice = distance * 0.05 + weight * distance * (0.4 * 0.05);
                    }
                    else if (weight > 10 && weight <= 40)
                    {
                        deliveryPrice = distance * 0.1 + weight * distance * (0.05 * 0.1);
                    }
                    else if (weight > 40 && weight <= 90)
                    {
                        deliveryPrice = distance * 0.15 + weight * distance * (0.02 * 0.15);
                    }
                    else if (weight > 90 && weight <= 150)
                    {
                        deliveryPrice = distance * 0.2 + weight * distance * (0.01 * 0.2);
                    }
                    break;
            }
            Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg. would cost {deliveryPrice:f2} lv.");
        }
    }
}
