using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfCars = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] carInfo = Console.ReadLine().Split();
            string model = carInfo[0];
            int fuelAmount = int.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);

            Car car = new Car(model, fuelAmount, fuelConsumption);
            cars.Add(car);
        }

        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] drivingInfo = input.Split();
            string model = drivingInfo[1];
            double distance = double.Parse(drivingInfo[2]);
            Car existingCar = cars.First(x => x.Model == model);
            existingCar.Move(distance);

            input = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTravelled}");
        }
    } 
}
