namespace AnimalCentre.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        int Happiness { get; }
        int Energy { get; }
        int ProcedureTime { get; }
        string Owner { get; set; }
        bool IsAdopt { get; set; }
        bool IsChipped { get; }
        bool IsVaccinated { get; }

        void AddHappiness(int happiness);
        void RemoveHappiness(int happiness);
        void AddEnergy(int energy);
        void RemoveEnergy(int energy);
        void SubstractProcedureTime(int procedureTime);
        void Vaccinate();
        void Chip();
    }
}
