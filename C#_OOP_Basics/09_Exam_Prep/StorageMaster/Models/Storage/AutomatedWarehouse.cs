using System.Collections.Generic;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public class AutomatedWarehouse : Storage
    {
        private const int DefaultCapacity = 1;
        private const int DefaultGarageSlots = 2;

        public AutomatedWarehouse(string name) : base(name, DefaultCapacity, DefaultGarageSlots, new List<Vehicle>(){new Truck()})
        {
        }
    }
}
