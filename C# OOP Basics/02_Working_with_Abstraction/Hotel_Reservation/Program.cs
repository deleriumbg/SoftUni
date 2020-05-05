using System;

namespace Hotel_Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PriceCalculator calculator = new PriceCalculator();
            calculator.ParseInput(input);
            decimal price = calculator.CalculatePrice();
            Console.WriteLine($"{price:f2}");
        }
    }
}
