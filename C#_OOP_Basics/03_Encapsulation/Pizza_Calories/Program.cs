using System;
using System.Collections.Generic;

namespace Pizza_Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split()[1];
                Pizza pizza = new Pizza(pizzaName);

                string[] doughInfo = Console.ReadLine().Split();
                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                pizza.AddDough(dough);

                string toppingInput = Console.ReadLine();
                while (toppingInput != "END")
                {
                    string[] toppingInfo = toppingInput.Split();
                    Topping topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));
                    pizza.AddTopping(topping);
                    toppingInput = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}
