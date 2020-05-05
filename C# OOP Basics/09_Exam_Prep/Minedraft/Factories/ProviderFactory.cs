using System.Collections.Generic;

public class ProviderFactory
{
    public Provider CreateProvider(List<string> args)
    {
        string type = args[0];

        switch (type)
        {
            case "Pressure":
                return new PressureProvider(args[1], double.Parse(args[2]));
            case "Solar":
                return new SolarProvider(args[1], double.Parse(args[2]));
            default:
                return null;
        }
    }
}
