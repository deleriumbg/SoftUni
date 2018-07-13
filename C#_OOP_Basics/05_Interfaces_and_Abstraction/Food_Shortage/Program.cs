using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<IBuyer> buyers = new List<IBuyer>();
        int inputCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputCount; i++)
        {
            string[] inputArgs = Console.ReadLine().Split();
            switch (inputArgs.Length)
            {
                case 3:
                    IBuyer rebel = new Rebel(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                    buyers.Add(rebel);
                    break;
                case 4:
                    IBuyer citizen = new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3]);
                    buyers.Add(citizen);
                    break;
            }
        }

        string foodBuyer = Console.ReadLine();
        while (foodBuyer != "End")
        {
            if (buyers.Any(x => x.Name == foodBuyer))
            {
                IBuyer buyer = buyers.First(x => x.Name == foodBuyer);
                buyer.BuyFood();
            }
            foodBuyer = Console.ReadLine();
        }

        Console.WriteLine(buyers.Sum(x => x.Food));
    }
}
