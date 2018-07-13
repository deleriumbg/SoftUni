using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName, salary)
    {
        privates = new List<ISoldier>();
    }

    private ICollection<ISoldier> privates;

    public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>) this.privates;

    public void AddPrivate(ISoldier soldier)
    {
        this.privates.Add(soldier);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine(base.ToString())
            .AppendLine("Privates:");

        foreach (var @private in this.Privates)
        {
            result.AppendLine($"  {@private.ToString()}");
        }

        return result.ToString().TrimEnd();
    }
}
