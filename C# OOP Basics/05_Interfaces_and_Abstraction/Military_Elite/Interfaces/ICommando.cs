using System.Collections.Generic;

public interface ICommando : ISpecialisedSoldier
{
    IReadOnlyCollection<IMission> Missions { get; }
    void AddMission(IMission mission);
    void CompleteMission(string missionCodeName);
}
