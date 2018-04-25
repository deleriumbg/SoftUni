using System;

namespace Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int chefs = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int gofrettes = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double sumPerChef = cakes * 45 + gofrettes * 5.80 + pancakes * 3.20;
            double totalSum = sumPerChef * chefs * days;
            double result = totalSum - (totalSum / 8);
            Console.WriteLine($"{result:f2}");
        }
    }
}
