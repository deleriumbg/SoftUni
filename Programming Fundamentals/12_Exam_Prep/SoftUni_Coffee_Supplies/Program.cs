using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Coffee_Supplies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] delimiters = Console.ReadLine().Split(' ');
            string input = Console.ReadLine();
            Dictionary<string, string> personsPreferredCoffee = new Dictionary<string, string>();
            Dictionary<string, long> coffeeTypeQuantities = new Dictionary<string, long>();

            while (input != "end of info")
            {
                if (input.Contains(delimiters[0]))
                {
                    string[] coffeeInfo = input.Split(new[] { delimiters[0] }, StringSplitOptions.RemoveEmptyEntries);
                    string personName = coffeeInfo[0];
                    string coffeeType = coffeeInfo[1];
                    personsPreferredCoffee.Add(personName, coffeeType);
                }
                else
                {
                    string[] coffeeInfo = input.Split(new[] { delimiters[1] }, StringSplitOptions.RemoveEmptyEntries);
                    string coffeeType = coffeeInfo[0];
                    long quantity = long.Parse(coffeeInfo[1]);
                    if (!coffeeTypeQuantities.ContainsKey(coffeeType))
                    {
                        coffeeTypeQuantities[coffeeType] = 0;
                    }
                    coffeeTypeQuantities[coffeeType] += quantity;
                }
                input = Console.ReadLine();
            }

            string input2 = Console.ReadLine();
            while (input2 != "end of week")
            {
                string[] coffeeConsumation = input2.Split(' ');
                string person = coffeeConsumation[0];
                int count = int.Parse(coffeeConsumation[1]);
                string personsCoffee = personsPreferredCoffee[person];
                coffeeTypeQuantities[personsCoffee] -= count;
                if (coffeeTypeQuantities[personsCoffee] <= 0)
                {
                    Console.WriteLine($"Out of {personsCoffee}");
                }
                input2 = Console.ReadLine();
            }

            Console.WriteLine("Coffee Left:");
            var coffeeLeft = coffeeTypeQuantities.Where(x => x.Value > 0).OrderByDescending(x => x.Value);
            foreach (var coffee in coffeeLeft)
            {
                Console.WriteLine($"{coffee.Key} {coffee.Value}");
            }

            Console.WriteLine("For:");
            foreach (var person in personsPreferredCoffee.Where(x => coffeeTypeQuantities.ContainsKey(x.Value))
                .OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{person.Key} {person.Value}");
            }
        }
    }
}
