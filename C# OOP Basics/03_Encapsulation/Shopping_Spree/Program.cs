using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                ParsePeople(people);
                ParseProducts(products);
                PrintPurchaseMessage(people, products);

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }

        private static void PrintPurchaseMessage(List<Person> people, List<Product> products)
        {
            string purchaseInput = Console.ReadLine();
            while (purchaseInput != "END")
            {
                string[] purchaseInfo = purchaseInput.Split();
                string purchaserName = purchaseInfo[0];
                string purchasedProduct = purchaseInfo[1];

                Person purchaser = people.First(x => x.Name == purchaserName);
                Product productToPurchase = products.First(x => x.Name == purchasedProduct);
                purchaser.TryToBuyProduct(productToPurchase);
                purchaseInput = Console.ReadLine();
            }
        }

        private static void ParseProducts(List<Product> products)
        {
            string[] allProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var currentProduct in allProducts)
            {
                string[] personInfo = currentProduct.Split('=');
                Product product = new Product(personInfo[0], decimal.Parse(personInfo[1]));
                products.Add(product);
            }
        }

        private static void ParsePeople(List<Person> people)
        {
            string[] allPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var currentPerson in allPeople)
            {
                string[] personInfo = currentPerson.Split('=');
                Person person = new Person(personInfo[0], decimal.Parse(personInfo[1]));
                people.Add(person);
            }
        }
    }
}
