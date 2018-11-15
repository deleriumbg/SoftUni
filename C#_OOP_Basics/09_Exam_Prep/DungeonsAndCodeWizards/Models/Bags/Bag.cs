using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private const int DefaultCapacity = 100;

        private List<Item> items;

        public int Capacity { get; private set; }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        protected Bag()
        {
            this.Capacity = DefaultCapacity;
            this.items = new List<Item>();
        }

        protected Bag(int capacity) : this()
        {
            this.Capacity = capacity;
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);
            return item;
        }
    }
}
