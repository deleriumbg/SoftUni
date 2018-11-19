using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Hotel;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private List<Animal> animals;
        private Dictionary<string, List<Animal>> procedures;
        private readonly Dictionary<string, List<string>> adoptedAnimals;
        private readonly Hotel hotel;

        public AnimalCentre()
        {
            this.animals = new List<Animal>();
            this.procedures = new Dictionary<string, List<Animal>>();
            this.adoptedAnimals = new Dictionary<string, List<string>>();
            this.hotel = new Hotel();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            Animal animal = null;
            switch (type)
            {
                 case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
            }
            this.hotel.Accommodate(animal);
            return $"Animal {animal.Name} registered successfully";
        }	

        public string Chip(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            Chip chip = new Chip();
            Animal animal = (Animal) this.hotel.Animals[name];
            chip.DoService(animal, procedureTime);

            if (!this.procedures.ContainsKey("Chip"))
            {
                this.procedures.Add("Chip", new List<Animal>());
            }
            this.procedures["Chip"].Add(animal);
            return $"{animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            Vaccinate vaccinate = new Vaccinate();
            Animal animal = (Animal) this.hotel.Animals[name];
            vaccinate.DoService(animal, procedureTime);

            if (!this.procedures.ContainsKey("Vaccinate"))
            {
                this.procedures.Add("Vaccinate", new List<Animal>());
            }
            this.procedures["Vaccinate"].Add(animal);
            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            Fitness fitness = new Fitness();
            Animal animal = (Animal) this.hotel.Animals[name];
            fitness.DoService(animal, procedureTime);

            if (!this.procedures.ContainsKey("Fitness"))
            {
                this.procedures.Add("Fitness", new List<Animal>());
            }
            this.procedures["Fitness"].Add(animal);
            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            Play play = new Play();
            Animal animal = (Animal) this.hotel.Animals[name];
            play.DoService(animal, procedureTime);

            if (!this.procedures.ContainsKey("Play"))
            {
                this.procedures.Add("Play", new List<Animal>());
            }
            this.procedures["Play"].Add(animal);
            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            DentalCare dentalCare = new DentalCare();
            Animal animal = (Animal) this.hotel.Animals[name];
            dentalCare.DoService(animal, procedureTime);

            if (!this.procedures.ContainsKey("DentalCare"))
            {
                this.procedures.Add("DentalCare", new List<Animal>());
            }
            this.procedures["DentalCare"].Add(animal);
            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            NailTrim nailTrim = new NailTrim();
            Animal animal = (Animal) this.hotel.Animals[name];
            nailTrim.DoService(animal, procedureTime);

            if (!this.procedures.ContainsKey("NailTrim"))
            {
                this.procedures.Add("NailTrim", new List<Animal>());
            }
            this.procedures["NailTrim"].Add(animal);
            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            CheckIfAnimalExists(animalName);
            Animal animal = (Animal) this.hotel.Animals[animalName];
            this.hotel.Adopt(animalName, owner);
            if (!this.adoptedAnimals.ContainsKey(owner))
            {
                this.adoptedAnimals.Add(owner, new List<string>());
            }
            this.adoptedAnimals[owner].Add(animalName);

            return animal.IsChipped ? $"{owner} adopted animal with chip" : $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            
            StringBuilder sb = new StringBuilder();
            foreach (var proc in procedures.Where(x => x.Key == type))
            {
                sb.AppendLine(proc.Key);
                foreach (var animal in proc.Value)
                {
                    sb.AppendLine($"{animal.ToString()}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public void End()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var owner in adoptedAnimals.OrderBy(o => o.Key))
            {
                sb.AppendLine($"--Owner: {owner.Key}");
                sb.AppendLine($"    - Adopted animals: {string.Join(" ", owner.Value)}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private void CheckIfAnimalExists(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }
    }
}
