using System;
using System.Collections.Generic;

public class HarvesterController : IHarvesterController
{
    private string mode;
    private readonly IEnergyRepository energyRepository;
    private readonly IList<IHarvester> harvesters;
    private readonly IHarvesterFactory factory;

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory factory)
    {
        this.mode = Constants.DefaultMode;
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.factory = factory;
    }

    public double OreProduced { get; private set; }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }

    public string Produce()
    {
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.mode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        //check if we can mine
        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            //mine
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.Produce();
            }
        }

        if (this.mode == "Energy")
        {
            minedOres = minedOres * 20 / 100;
        }
        else if (this.mode == "Half")
        {
            minedOres = minedOres * 50 / 100;
        }

        this.OreProduced += minedOres;
        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public IReadOnlyCollection<IEntity> Entities => (IReadOnlyCollection<IHarvester>)this.harvesters;

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        List<IHarvester> remainder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception)
            {
                remainder.Add(harvester);
            }
        }

        foreach (var entity in remainder)
        {
            this.harvesters.Remove(entity);
        }
        return string.Format(Constants.ModeChange, mode);
    }
}
