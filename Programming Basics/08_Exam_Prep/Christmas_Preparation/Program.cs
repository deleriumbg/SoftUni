using System;

namespace Christmas_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int wrappingPaper = int.Parse(Console.ReadLine());
            int clothRolls = int.Parse(Console.ReadLine());
            double glueLiters = double.Parse(Console.ReadLine());
            int discountPercentage = int.Parse(Console.ReadLine());

            double allExpences = wrappingPaper * 5.80 + clothRolls * 7.20 + glueLiters * 1.20;
            double totalPrice = allExpences - ((allExpences * discountPercentage) / 100);
            Console.WriteLine($"{totalPrice:f3}");
        }
    }
}
