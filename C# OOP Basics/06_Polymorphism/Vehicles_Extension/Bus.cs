using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption + 1.4, tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
    }
}
