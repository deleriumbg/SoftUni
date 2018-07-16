using System;

class Program
{
    static void Main(string[] args)
    {
        string[] carInfo = Console.ReadLine().Split();
        Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

        string[] truckInfo = Console.ReadLine().Split();
        Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

        string[] busInfo = Console.ReadLine().Split();
        Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCommands; i++)
        {
            try
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "Drive")
                {
                    if (command[1] == "Car")
                    {
                        car.Drive(double.Parse(command[2]));
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Drive(double.Parse(command[2]));
                    }
                    else if (command[1] == "Bus")
                    {
                        bus.Drive(double.Parse(command[2]));
                    }
                }
                else if (command[0] == "Refuel")
                {
                    if (command[1] == "Car")
                    {
                        car.Refuel(double.Parse(command[2]));
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(command[2]));
                    }
                    else if (command[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(command[2]));
                    }
                }
                else if (command[0] == "DriveEmpty")
                {
                    bus.FuelConsumption -= 1.4;
                    bus.Drive(double.Parse(command[2]));
                }
            }
            catch (Exception argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
        Console.WriteLine($"{car}\r\n{truck}\r\n{bus}");
    }
}