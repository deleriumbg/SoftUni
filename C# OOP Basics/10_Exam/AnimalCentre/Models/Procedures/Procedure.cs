using System;
using System.Collections.Generic;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<Animal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<Animal>();
        }

        public IReadOnlyCollection<Animal> ProcedureHistory => this.procedureHistory.AsReadOnly();

        public abstract string History();

        public abstract void DoService(IAnimal animal, int procedureTime);

        protected void CheckProcedureTime(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException($"Animal doesn't have enough procedure time");
            }
        }
    }
}
