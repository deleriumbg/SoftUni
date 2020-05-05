using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Nation airNation;
    private Nation earthNation;
    private Nation fireNation;
    private Nation waterNation;
    private List<string> warHistory;

    public NationsBuilder()
    {
        this.airNation = new Nation();
        this.earthNation = new Nation();
        this.fireNation = new Nation();
        this.waterNation = new Nation();
        this.warHistory = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        switch (type)
        {
            case "Air":
                AirBender airBender = new AirBender(benderArgs[1], int.Parse(benderArgs[2]), double.Parse(benderArgs[3]));
                this.airNation.AddBender(airBender);
                break;
            case "Earth":
                EarthBender earthBender = new EarthBender(benderArgs[1], int.Parse(benderArgs[2]), double.Parse(benderArgs[3]));
                this.earthNation.AddBender(earthBender);
                break;
            case "Fire":
                FireBender fireBender = new FireBender(benderArgs[1], int.Parse(benderArgs[2]), double.Parse(benderArgs[3]));
                this.fireNation.AddBender(fireBender);
                break;
            case "Water":
                WaterBender waterBender = new WaterBender(benderArgs[1], int.Parse(benderArgs[2]), double.Parse(benderArgs[3]));
                this.waterNation.AddBender(waterBender);
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        switch (type)
        {
            case "Air":
                AirMonument airMonument = new AirMonument(monumentArgs[1], int.Parse(monumentArgs[2]));
                this.airNation.AddMonument(airMonument);
                break;
            case "Earth":
                EarthMonument earthMonument = new EarthMonument(monumentArgs[1], int.Parse(monumentArgs[2]));
                this.earthNation.AddMonument(earthMonument);
                break;
            case "Fire":
                FireMonument fireMonument = new FireMonument(monumentArgs[1], int.Parse(monumentArgs[2]));
                this.fireNation.AddMonument(fireMonument);
                break;
            case "Water":
                WaterMonument waterMonument = new WaterMonument(monumentArgs[1], int.Parse(monumentArgs[2]));
                this.waterNation.AddMonument(waterMonument);
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();
        Nation nation = null;
        switch (nationsType)
        {
            case "Air":
                nation = airNation;
                break;
            case "Earth":
                nation = earthNation;
                break;
            case "Fire":
                nation = fireNation;
                break;
            case "Water":
                nation = waterNation;
                break;
        }

        sb.AppendLine($"{nationsType} Nation").Append("Benders:");
        if (nation.Benders.Count == 0)
        {
            sb.Append(" None");
        }

        sb.AppendLine();
        foreach (var bender in nation.Benders)
        {
            sb.AppendLine($"###{bender.ToString()}");
        }

        sb.Append("Monuments:");
        if (nation.Monuments.Count == 0)
        {
            sb.Append(" None");
        }

        sb.AppendLine();
        foreach (var monument in nation.Monuments)
        {
            sb.AppendLine($"###{monument.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }

    public void IssueWar(string nationsType)
    {
        this.warHistory.Add(nationsType);
        List<Nation> allNations = new List<Nation>{airNation, earthNation, fireNation, waterNation};
        foreach (var nation in allNations.OrderByDescending(x => x.TotalPower).Skip(1))
        {
            nation.ClearBenders();
            nation.ClearMonuments();
        }
    }

    public string GetWarsRecord() 
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= this.warHistory.Count; i++)
        {
            sb.AppendLine($"War {i} issued by {this.warHistory[i - 1]}");
        }

        return sb.ToString().TrimEnd();
    }
}
