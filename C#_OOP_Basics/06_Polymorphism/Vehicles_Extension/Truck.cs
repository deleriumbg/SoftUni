using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption + 1.6, tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
    }

    public override void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        else
        {
            double totalFuel = base.FuelQuantity + liters * 0.95;
            if (totalFuel > base.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                base.FuelQuantity += liters * 0.95;
            }
        }
    }
}
