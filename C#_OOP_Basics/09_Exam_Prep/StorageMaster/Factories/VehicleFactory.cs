using System;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            switch (type)
            {
                  case "Van":
                    return new Van();
                  case "Truck":
                      return new Truck();
                  case "Semi":
                      return new Semi();
                  default:
                      throw new InvalidOperationException("Invalid vehicle type!");
            }
        }
    }
}
