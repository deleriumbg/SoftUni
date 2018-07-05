using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int amountOfCars = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < amountOfCars; i++)
        {
            string[] carInfo = Console.ReadLine().Split();
            string model = carInfo[0];
            int engineSpeed = int.Parse(carInfo[1]);
            int enginePower = int.Parse(carInfo[2]);
            int cargoWeight = int.Parse(carInfo[3]);
            string cargoType = carInfo[4];

            Car car = new Car(model)
            {
                Engine = new Engine(enginePower, engineSpeed),
                Cargo = new Cargo(cargoWeight, cargoType)
            };
            for (int j = 5; j <= 12; j+=2)
            {
                Tire tire = new Tire(double.Parse(carInfo[j]), int.Parse(carInfo[j + 1]));
                car.Tires.Add(tire);
            }
            cars.Add(car);
        }

        string command = Console.ReadLine();
        switch (command)
        {
            case "fragile":
                cars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(t => t.Pressure < 1)).ToList();
                break;
            case "flamable":
                cars = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();
                break;
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model}");
        }
    }
}
