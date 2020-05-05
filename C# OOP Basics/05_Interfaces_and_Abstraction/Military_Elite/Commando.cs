using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary, corps)
    {
        this.missions = new List<IMission>();
    }

    private ICollection<IMission> missions;
    public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>) missions;

    public void AddMission(IMission mission)
    {
        missions.Add(mission);
    }

    public void CompleteMission(string missionCodeName)
    {
        IMission mission = this.Missions.FirstOrDefault(x => x.CodeName == missionCodeName);
        if (mission == null)
        {
            throw new ArgumentException("Mission not found!");
        }

        mission.Complete();
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine(base.ToString())
            .AppendLine($"Corps: {this.Corps}")
            .AppendLine("Missions:");

        foreach (var mission in this.Missions)
        {
            result.AppendLine($"  {mission.ToString()}");
        }

        return result.ToString().TrimEnd();
    }
}
