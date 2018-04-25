using System;

namespace Mobile_Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractTime = Console.ReadLine();
            string contractType = Console.ReadLine();
            string addedInternet = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());
            double price = 0;
            switch (contractType)
            {
                case "Small":
                    if (contractTime == "one")
                    {
                        price = months * 9.98;
                    }
                    else if (contractTime == "two")
                    {
                        price = months * 8.58;
                    }
                    if (addedInternet == "yes")
                    {
                        price += months * 5.5;
                    }
                    break;
                case "Middle":
                    if (contractTime == "one")
                    {
                        price = months * 18.99;
                    }
                    else if (contractTime == "two")
                    {
                        price = months * 17.09;
                    }
                    if (addedInternet == "yes")
                    {
                        price += months * 4.35;
                    }
                    break;
                case "Large":
                    if (contractTime == "one")
                    {
                        price = months * 25.98;
                    }
                    else if (contractTime == "two")
                    {
                        price = months * 23.59;
                    }
                    if (addedInternet == "yes")
                    {
                        price += months * 4.35;
                    }
                    break;
                case "ExtraLarge":
                    if (contractTime == "one")
                    {
                        price = months * 35.99;
                    }
                    else if (contractTime == "two")
                    {
                        price = months * 31.79;
                    }
                    if (addedInternet == "yes")
                    {
                        price += months * 3.85;
                    }
                    break;
            }
            if (contractTime == "two")
            {
                price *= 0.9625;
            }
            Console.WriteLine($"{price:f2} lv.");
        }
    }
}
