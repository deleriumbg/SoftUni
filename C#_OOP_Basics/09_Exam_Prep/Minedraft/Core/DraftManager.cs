using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private const double HalfModeEnergyRequirments = 0.6;
    private const double HalfModeOreOutput = 0.5;

    private readonly HarvesterFactory harvesterFactory;
    private readonly ProviderFactory providerFactory;
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private string mode;
    private double totalEnergyStored;
    private double totalMinedOre;

    public DraftManager()
    {
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = "Full";
        this.totalEnergyStored = 0;
        this.totalMinedOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            var harvester = this.harvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(harvester);
            return $"Successfully registered {type} Harvester - {id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            var provider = this.providerFactory.CreateProvider(arguments);
            this.providers.Add(provider);
            return $"Successfully registered {type} Provider - {id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string Day()
    {
        double totalHarvesterEnergy = this.harvesters.Sum(e => e.EnergyRequirement);
        double summedEnergyOutput = this.providers.Sum(e => e.EnergyOutput);
        double summedOreOutput = 0;

        this.totalEnergyStored += summedEnergyOutput;

        if (this.mode == "Full" && totalHarvesterEnergy <= this.totalEnergyStored)
        {
            summedOreOutput = this.harvesters.Sum(o => o.OreOutput);
            this.totalEnergyStored -= totalHarvesterEnergy;
            this.totalMinedOre += summedOreOutput;
        }
        else if (this.mode == "Half")
        {
            double halfTotalHarvesterEnergy = totalHarvesterEnergy * HalfModeEnergyRequirments;
            if (halfTotalHarvesterEnergy <= this.totalEnergyStored)
            {
                summedOreOutput = (this.harvesters.Sum(o => o.OreOutput)) * HalfModeOreOutput;
                this.totalEnergyStored -= halfTotalHarvesterEnergy;
                this.totalMinedOre += summedOreOutput;
            }
        }
        return $"A day has passed.\nEnergy Provided: {summedEnergyOutput}\nPlumbus Ore Mined: {summedOreOutput}";
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        Machine machine = (Machine) this.harvesters.FirstOrDefault(h => h.Id == id) ??
                          this.providers.FirstOrDefault(p => p.Id == id);

        return machine == null ? $"No element found with id - {id}" : machine.ToString();
    }
    public string ShutDown()
    {
        return
            $"System Shutdown\nTotal Energy Stored: {this.totalEnergyStored}\nTotal Mined Plumbus Ore: {this.totalMinedOre}";
    }
}
