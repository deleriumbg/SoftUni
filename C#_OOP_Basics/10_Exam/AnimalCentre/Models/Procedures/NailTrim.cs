using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        public NailTrim():base()
        {
            this.procedureHistory = new List<Animal>();
        }

        private List<Animal> procedureHistory;
        public IReadOnlyCollection<Animal> ProcedureHistory => this.procedureHistory.AsReadOnly();
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckProcedureTime(animal, procedureTime);
            animal.RemoveHappiness(7);
            animal.SubstractProcedureTime(procedureTime);
            this.procedureHistory.Add((Animal)animal);
        }

        public override string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NailTrim");
            foreach (var animal in this.ProcedureHistory)
            {
                sb.AppendLine(
                    $"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
