using System;
using System.Collections.Generic;
using System.Linq;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public abstract class Storage
    {
        private Vehicle[] garage;
        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[this.GarageSlots];
            this.products = new List<Product>();
            this.FillGarageWithInitialVehicles(vehicles);
        }

        private int AddVehicleToGarage(Vehicle vehicle)
        {
            int freeGarageSlotIndex = Array.IndexOf(this.garage, null);

            if (freeGarageSlotIndex == -1)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[freeGarageSlotIndex] = vehicle;

            return freeGarageSlotIndex;
        }

        private void FillGarageWithInitialVehicles(IEnumerable<Vehicle> vehicles)
        {
            int index = 0;

            foreach (Vehicle vehicle in vehicles)
            {
                this.garage[index++] = vehicle;
            }
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull => this.products.Sum(x => x.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public double TotalProductsPrice => this.products.Sum(p => p.Price);

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            Vehicle vehicle = this.garage[garageSlot];

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            
            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            int foundGarageSlotIndex = deliveryLocation.AddVehicleToGarage(vehicle);
            this.garage[garageSlot] = null;

            return foundGarageSlotIndex;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = GetVehicle(garageSlot);

            int unloadedProducts = 0;
            foreach (Product product in vehicle.Trunk)
            {
                if (!vehicle.IsEmpty)
                {
                    if (!this.IsFull)
                    {
                        this.products.Add(product);
                        unloadedProducts++;
                    }
                }
            }

            return unloadedProducts;
        }
    }
}
