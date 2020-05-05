using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private readonly ProductFactory productFactory;
        private readonly StorageFactory storageFactory;
        private List<Product> products;
        private List<Storage> storages;
        private Vehicle vehicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.products = new List<Product>();
            this.storages = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);
            this.products.Add(product);
            return $"Added {type} to pool";
        }	

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            this.storages.Add(storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(s => s.Name == storageName);
            Vehicle currentVehicle = storage.GetVehicle(garageSlot);
            this.vehicle = currentVehicle;
            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            foreach (var name in productNames)
            {
                Product product = this.products.FirstOrDefault(p => p.GetType().Name == name);
                if (product == null)
                {
                    throw new InvalidOperationException($"{name} is out of stock!");
                }

                product = this.products.Last(p => p.GetType().Name == name);
                this.products.Remove(product);
                if (this.vehicle.IsFull)
                {
                    return $"Loaded {this.vehicle.Trunk.Count}/{productNames.ToList().Count} products into {this.vehicle.GetType().Name}";
                }
                this.vehicle.LoadProduct(product);
            }
            return $"Loaded {this.vehicle.Trunk.Count}/{productNames.ToList().Count} products into {this.vehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourceStorage = this.storages.FirstOrDefault(s => s.Name == sourceName);
            if (sourceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            Storage destinationStorage = this.storages.FirstOrDefault(s => s.Name == destinationName);
            if (destinationStorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            int destinationSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(s => s.Name == storageName);
            Vehicle vehicle = storage.GetVehicle(garageSlot);
            int unloadedProducts = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProducts}/{vehicle.Trunk.Count} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            StringBuilder sb = new StringBuilder();
            Storage storage = this.storages.FirstOrDefault(s => s.Name == storageName);

            double allProductsWeight = storage.Products.Sum(p => p.Weight);
            var sortedProducts = storage
                .Products
                .GroupBy(c => c.GetType().Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .ToList();

            List<string> sortedProductsToString = new List<string>();
            foreach (var product in sortedProducts.OrderByDescending(p => p.Count).ThenBy(p => p.Name))
            {
                sortedProductsToString.Add($"{product.Name} ({product.Count})");
            }

            sb.AppendLine($"Stock ({allProductsWeight}/{storage.Capacity}): [{string.Join(", ", sortedProductsToString)}]");

            List<string> vehicleInGarage = new List<string>();
            foreach (Vehicle vehicle in storage.Garage)
            {
                vehicleInGarage.Add(vehicle == null ? "empty" : vehicle.GetType().Name);
            }

            sb.AppendLine($"Garage: [{string.Join("|", vehicleInGarage)}]");
            return sb.ToString().Trim();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Storage storage in this.storages.OrderByDescending(s => s.TotalProductsPrice))
            {
                sb.AppendLine($"{storage.Name}:").AppendLine($"Storage worth: ${storage.TotalProductsPrice:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}
