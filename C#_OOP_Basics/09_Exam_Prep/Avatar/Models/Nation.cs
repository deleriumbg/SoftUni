using System.Collections.Generic;
using System.Linq;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public IReadOnlyCollection<Bender> Benders => this.benders.AsReadOnly();
    public IReadOnlyCollection<Monument> Monuments => this.monuments.AsReadOnly();

    public void AddBender(Bender bender) => this.benders.Add(bender);
    public void AddMonument(Monument monument) => this.monuments.Add(monument);

    public void ClearBenders() => this.benders.Clear();
    public void ClearMonuments() => this.monuments.Clear();

    public double TotalPower => this.GetTotalPower();

    private double GetTotalPower()
    {
        double bendersPower = this.Benders.Sum(b => b.GetBenderPower());
        double monumentPower = this.Monuments.Sum(m => m.GetMonumentPower());
        double totalPower = bendersPower + ((bendersPower / 100) * monumentPower);
        return totalPower;
    }
}
