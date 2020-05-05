using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfEngines = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < numberOfEngines; i++)
        {
            string[] engineInfo = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            string model = engineInfo[0];
            double power = double.Parse(engineInfo[1]);

            switch (engineInfo.Length)
            {
                case 2:
                    engines.Add(new Engine(model, power));
                    break;
                case 3:
                    bool isDisplacement = double.TryParse(engineInfo[2], out double displacement);
                    engines.Add(!isDisplacement
                        ? new Engine(model, power, 0.0, engineInfo[2])
                        : new Engine(model, power, displacement));
                    break;
                case 4:
                    engines.Add(new Engine(model, power, double.Parse(engineInfo[2]), engineInfo[3]));
                    break;
            }
        }

        int numberOfCars = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] carInfo = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            string model = carInfo[0];
            Engine engine = engines.First(x => x.Model == carInfo[1]);

            switch (carInfo.Length)
            {
                case 2:
                    cars.Add(new Car(model, engine));
                    break;
                case 3:
                    bool isWeight = double.TryParse(carInfo[2], out double weight);
                    cars.Add(!isWeight
                        ? new Car(model, engine, 0.0, carInfo[2])
                        : new Car(model, engine, weight));
                    break;
                case 4:
                    cars.Add(new Car(model, engine, double.Parse(carInfo[2]), carInfo[3]));
                    break;
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}
