using System;

public class Mission : IMission
{
    public string CodeName { get; private set; }
    public MissionState State { get; private set; }

    public Mission(string codeName, string missionState)
    {
        CodeName = codeName;
        ParseMissionState(missionState);
    }

    private void ParseMissionState(string missionState)
    {
        bool isValid = Enum.TryParse(typeof(MissionState), missionState, out object validMissionState);
        if (!isValid)
        {
            throw new ArgumentException("Invalid mission state!");
        }
        this.State = (MissionState)validMissionState;
    }

    public void Complete()
    {
        this.State = MissionState.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }
}
