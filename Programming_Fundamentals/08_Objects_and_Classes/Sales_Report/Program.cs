using System;
using System.Linq;

namespace Sales_Report
{
    class Program
    {
        static void Main(string[] args)
        {
            Sale[] sales = ReadSales();
            var towns = sales.Select(s => s.Town).Distinct().OrderBy(t => t);
            foreach (string town in towns)
            {
                var salesByTown = sales.Where(s => s.Town == town).Select(s => s.Price * s.Quantity);
                Console.WriteLine($"{town} -> {salesByTown.Sum():f2}");
            }
        }

        public static Sale ReadSale()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            Sale sale = new Sale();
            sale.Town = input[0];
            sale.Product = input[1];
            sale.Price = double.Parse(input[2]);
            sale.Quantity = double.Parse(input[3]);
            return sale;
        }

        public static Sale[] ReadSales()
        {
            int n = int.Parse(Console.ReadLine());
            Sale[] sales = new Sale[n];
            for (int i = 0; i < n; i++)
            {
                sales[i] = ReadSale();
            }
            return sales;
        }
    }

    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
