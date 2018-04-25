using System;

namespace Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            double price = 0;
            string hallType = "";

            if (groupSize <= 50)
            {
                price = 2500;
                hallType = "Small Hall";
            }
            else if (groupSize <= 100)
            {
                price = 5000;
                hallType = "Terrace";
            }
            else if (groupSize <= 120)
            {
                price = 7500;
                hallType = "Great Hall";
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            switch (package)
            {
                case "Normal":
                    price = (price + 500) * 0.95;
                    break;
                case "Gold":
                    price = (price + 750) * 0.9;
                    break;
                case "Platinum":
                    price = (price + 1000) * 0.85;
                    break;
            }
            Console.WriteLine($"We can offer you the {hallType}\r\nThe price per person is {price / groupSize:f2}$");
        }
    }
}
