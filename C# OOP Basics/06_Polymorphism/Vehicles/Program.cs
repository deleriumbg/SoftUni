using System;

class Program
{
    static void Main(string[] args)
    {
        string[] carInfo = Console.ReadLine().Split();
        Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

        string[] truckInfo = Console.ReadLine().Split();
        Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] command = Console.ReadLine().Split();
            try
            {
                switch (command[0])
                {
                    case "Drive":
                        if (command[1] == "Car")
                        {
                            car.Drive(double.Parse(command[2]));
                        }
                        else
                        {
                            truck.Drive(double.Parse(command[2]));
                        }
                        break;
                    case "Refuel":
                        if (command[1] == "Car")
                        {
                            car.Refuel(double.Parse(command[2]));
                        }
                        else
                        {
                            truck.Refuel(double.Parse(command[2]));
                        }
                        break;
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
        Console.WriteLine($"Car: {car.FuelQuantity:f2}\r\nTruck: {truck.FuelQuantity:f2}");
    }
}