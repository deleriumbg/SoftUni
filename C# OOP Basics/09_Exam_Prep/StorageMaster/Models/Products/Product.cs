using System;

namespace StorageMaster.Models.Products
{
    public abstract class Product
    {
        private double price;

        public double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                this.price = value;
            }
        }

        public double Weight { get; private set; }

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }
    }
}
