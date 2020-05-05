using System;

public abstract class Vehicle
{
    public double FuelQuantity { get; private set; }
    public double TankCapacity { get; private set; }
    private double  fuelConsumption;

    public double  FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }


    protected Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public void Drive(double distance)
    {
        if (distance * this.FuelConsumption <= this.FuelQuantity)
        {
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            this.FuelQuantity -= distance * this.FuelConsumption;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
    }

    public virtual void Refuel(double liters)
    {
        this.FuelQuantity += liters;
    }
}
