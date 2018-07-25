using System;

public class TrafficLight
{
    private TrafficLightColors currentLightState;

    public TrafficLight(TrafficLightColors currentLightState)
    {
        this.currentLightState = currentLightState;
    }

    public void ChangeState()
    {
        this.currentLightState = (TrafficLightColors)(((int)this.currentLightState + 1) % Enum.GetNames(typeof(TrafficLightColors)).Length);
    }

    public override string ToString()
    {
        return this.currentLightState.ToString();
    }
}
