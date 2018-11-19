using System;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;
        private int procedureTime;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public string Name { get; private set; }

        public int Happiness
        {
            get
            {
                return happiness;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }

                happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return energy;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }

        public int ProcedureTime
        {
            get
            {
                return procedureTime;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Animal doesn't have enough procedure time");
                }

                procedureTime = value;
            }
        }

        public string Owner { get; set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; private set; }

        public bool IsVaccinated { get; private set; }

        public void AddHappiness(int happiness)
        {
            this.Happiness += happiness;
        }

        public void RemoveHappiness(int happiness)
        {
            this.Happiness -= happiness;
        }

        public void AddEnergy(int energy)
        {
            this.Energy += energy;
        }

        public void RemoveEnergy(int energy)
        {
            this.Energy -= energy;
        }

        public void SubstractProcedureTime(int procedureTime)
        {
            if (this.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
            this.ProcedureTime -= procedureTime;
        }

        public void Vaccinate()
        {
            this.IsVaccinated = true;
        }

        public void Chip()
        {
            this.IsChipped = true;
        }  

        public void SetOwner(string owner)
        {
            this.Owner = owner;
        }

        public void Adopt()
        {
            this.IsAdopt = true;
        }
    }
}
