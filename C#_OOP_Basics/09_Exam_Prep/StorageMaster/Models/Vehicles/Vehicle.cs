using System;
using System.Collections.Generic;
using System.Linq;
using StorageMaster.Models.Products;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private readonly List<Product> trunk;

        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();

        public int Capacity { get; }

        public bool IsFull => this.Trunk.Sum(x => x.Weight) >= this.Capacity;

        public bool IsEmpty => this.Trunk.Count == 0;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product product = this.trunk.Last();
            this.trunk.Remove(product);
            return product;
        }
    }
}
