using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        private const int DefaultCapacity = 10;

        private Dictionary<string, IAnimal> animals;
        public Hotel()
        {
            this.Capacity = DefaultCapacity;
            this.animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity { get; }

        public IReadOnlyDictionary<string, IAnimal> Animals => new ReadOnlyDictionary<string, IAnimal>(this.animals);

        public void Accommodate(IAnimal animal)
        {
            if (this.Animals.Count == this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            this.animals.Add(animal.Name, (Animal)animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal animal = this.Animals[animalName];
            animal.Owner = owner;
            animal.IsAdopt = true;
            this.animals.Remove(animalName);
        }
    }
}
