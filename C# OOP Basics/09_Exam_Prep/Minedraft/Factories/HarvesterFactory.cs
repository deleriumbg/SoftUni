using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> args)
    {
        string type = args[0];

        switch (type)
        {
            case "Hammer":
                return new HammerHarvester(args[1], double.Parse(args[2]), double.Parse(args[3]));
            case "Sonic":
                return new SonicHarvester(args[1], double.Parse(args[2]), double.Parse(args[3]), int.Parse(args[4]));
            default:
                return null;
        }
    }
}
