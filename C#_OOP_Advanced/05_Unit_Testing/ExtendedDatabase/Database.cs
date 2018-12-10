using System;
using System.Linq;

namespace ExtendedDatabase
{
    public class Database<T> where T :Person
    {
        private const int Capacity = 16;

        private T[] People;
        private int index = -1;

        public Database()
        {
            this.People = new T[Capacity];            
        }

        public Database(T[] items) :this()
        {
            if (items.Length > Capacity)
            {
                throw new InvalidOperationException($"Items must be less than {Capacity}");
            }

            for (int i = 0; i < items.Length; i++)
            {
                this.People[i] = items[i];
            }
            this.index = items.Length - 1;
        }

        public void Add(T item)
        {
            if (index >= Capacity - 1)
            {
                throw new InvalidOperationException($"Database is full. You cannot add any elements");
            }

            var currentItem = this.People.FirstOrDefault(e => e?.Id == item.Id || e?.Username == item.Username);

            if (currentItem != null)
            {
                throw new InvalidOperationException("Person with that Username or Id already exists!");
            }

            this.People[++index] = item;
        }

        public void Remove()
        {
            if (index < 0)
            {
                throw new InvalidOperationException("Database is empty. You cannot remove elements");
            }

            this.People[index] = default(T);
            index--;
        }

        public T[] Fetch()
        {
            if (index<0)
            {
                return new T[0];
            }

            T[] result = new T[index + 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = this.People[i];
            }
            return result;
        }

        public T FindByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(username, "Username cannot be null or whitespace");
            }

            var currentItem = this.People.FirstOrDefault(e => e?.Username == username);

            if (currentItem == null)
            {
                throw new InvalidOperationException($"There is not {typeof(T)} with this username");
            }

            return currentItem;
        }

        public T FindById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("The id must be a positive integer!");
            }

            var currentItem = this.People.FirstOrDefault(e => e?.Id == id);
            if (currentItem == null)
            {
                throw new InvalidOperationException($"The is no {typeof(T)} with id: {id}");
            }
            return currentItem;
        }
    }
}
