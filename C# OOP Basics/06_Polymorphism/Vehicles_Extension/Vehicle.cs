using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    public double FuelConsumption { get; protected internal set; }
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }

    public double TankCapacity
    {
        get { return tankCapacity; }
        set { tankCapacity = value; }
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set
        {
            if (value > TankCapacity)
            {
                value = 0;
            }
            fuelQuantity = value;
        }
    }

    public virtual void Drive(double distance)
    {
        double neededFuel = this.FuelConsumption * distance;
        if (neededFuel > FuelQuantity)
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }
        else
        {
            this.FuelQuantity -= neededFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }

    public virtual void Refuel(double fuelAmount)
    {
        if (fuelAmount > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
        }

        else if (fuelAmount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        else
        {
            this.fuelQuantity += fuelAmount;
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
