using System;
using System.Linq;

namespace Database
{
    public class Database : IDatabase
    {
        private const int Capacity = 16;

        private int[] data;
        private int index = -1;

        public Database()
        {
            this.data = new int[Capacity];            
        }

        public Database(int[] items) :this()
        {
            if (items.Length > Capacity)
            {
                throw new InvalidOperationException($"Items must be less than {Capacity}");
            }

            for (int i = 0; i < items.Length; i++)
            {
                this.data[i] = items[i];
            }
            this.index = items.Length - 1;
        }

        public void Add(int item)
        {
            if (index >= Capacity - 1)
            {
                throw new InvalidOperationException($"Database is full. You cannot add any elements");
            }

            this.data[++index] = item;
        }

        public void Remove()
        {
            if (index < 0)
            {
                throw new InvalidOperationException("Database is empty. You cannot remove elements");
            }

            this.data[index] = default(int);
            index--;
        }

        public int[] Fetch()
        {
            return this.data.Take(index + 1).ToArray();
        }
    }
}
