using System;

public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumption { get; set; }
    public double DistanceTravelled { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumption, double distanceTravelled = 0.0)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumption = fuelConsumption;
        DistanceTravelled = distanceTravelled;
    }

    public void Move(double distance)
    {
        if (FuelAmount >= FuelConsumption * distance)
        {
            DistanceTravelled += distance;
            FuelAmount -= FuelConsumption * distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
