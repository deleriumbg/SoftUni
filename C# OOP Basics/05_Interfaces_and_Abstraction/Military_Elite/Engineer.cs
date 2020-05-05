using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary, corps)
    {
        this.repairs = new List<IRepair>();
    }

    private ICollection<IRepair> repairs;
    public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>) repairs;

    public void AddRepair(IRepair repair)
    {
        this.repairs.Add(repair);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine(base.ToString())
            .AppendLine($"Corps: {this.Corps}")
            .AppendLine("Repairs:");

        foreach (var repair in this.Repairs)
        {
            result.AppendLine($"  {repair.ToString()}");
        }

        return result.ToString().TrimEnd();
    }
}
