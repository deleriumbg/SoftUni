using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<TrafficLight> allTrafficLights = new List<TrafficLight>();
        string[] inputSignal = Console.ReadLine().Split();
        int numberOfLightChanges = int.Parse(Console.ReadLine());

        foreach (var signal in inputSignal)
        {
            TrafficLightColors initialColorState = (TrafficLightColors)Enum.Parse(typeof(TrafficLightColors), signal);
            allTrafficLights.Add(new TrafficLight(initialColorState)); 
        }

        for (int i = 0; i < numberOfLightChanges; i++)
        {
            foreach (var trafficLight in allTrafficLights)
            {
                trafficLight.ChangeState();
            }
            Console.WriteLine(string.Join(" ", allTrafficLights));
        }
    }
}
