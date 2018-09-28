using System;
using System.Collections.Generic;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> parking = new HashSet<string>();

            while (input != "END")
            {
                string[] inputParams = input.Split(", ");
                string command = inputParams[0];
                string carNumber = inputParams[1];

                switch (command)
                {
                    case "IN":
                        parking.Add(carNumber);
                        break;
                    case "OUT":
                        if (parking.Contains(carNumber))
                        {
                            parking.Remove(carNumber);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
