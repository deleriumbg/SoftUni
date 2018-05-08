using System;
using System.Collections.Generic;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPassingPerGreen = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            while (input != "end")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else if (input == "green")
                {
                    int carsToPass = Math.Min(cars.Count, carsPassingPerGreen);
                    for (int i = 0; i < carsToPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        carsPassed++;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
