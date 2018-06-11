using System;
using System.Collections.Generic;
using System.Linq;

namespace Andrey_and_Billiard
{
    class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> ShopList { get; set; }
        public double Bill { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int entities = int.Parse(Console.ReadLine());
            Dictionary<string, double> shop = new Dictionary<string, double>();

            for (int i = 0; i < entities; i++)
            {
                string[] entity = Console.ReadLine().Split('-');
                string product = entity[0];
                double price = double.Parse(entity[1]);
                if (!shop.ContainsKey(product))
                {
                    shop.Add(product, price);
                }
                else
                {
                    shop[product] = price;
                }
            }

            List<Customer> customers = new List<Customer>();

            string clientOrder = Console.ReadLine();
            while (clientOrder != "end of clients")
            {
                string[] clientArgs = clientOrder.Split('-');
                string clientName = clientArgs[0];
                string[] order = clientArgs[1].Split(',');
                string orderedItem = order[0];
                int orderedQuantity = int.Parse(order[1]);

                if (shop.ContainsKey(orderedItem))
                {
                    if (!customers.Any(x => x.Name == clientName))
                    {
                        Customer customer = new Customer();
                        customer.Name = clientName;
                        customer.ShopList = new Dictionary<string, int>();
                        customer.ShopList.Add(orderedItem, orderedQuantity);
                        customer.Bill = shop[orderedItem] * orderedQuantity;
                        customers.Add(customer);
                    }
                    else
                    {
                        Customer existingCustomer = customers.Find(x => x.Name == clientName);
                        if (existingCustomer.ShopList.ContainsKey(orderedItem))
                        {
                            existingCustomer.ShopList[orderedItem] += orderedQuantity;
                        }
                        else
                        {
                            existingCustomer.ShopList.Add(orderedItem, orderedQuantity);
                        }                       
                        existingCustomer.Bill += shop[orderedItem] * orderedQuantity;
                    }
                }

                clientOrder = Console.ReadLine();
            }

            double totalBill = 0;
            foreach (var customer in customers.OrderBy(x => x.Name))
            {
                Console.WriteLine(customer.Name);
                foreach (var item in customer.ShopList)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }
                Console.WriteLine($"Bill: {customer.Bill:f2}");
                totalBill += customer.Bill;
            }

            Console.WriteLine($"Total bill: {totalBill:f2}");
        }
    }
}
