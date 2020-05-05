using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string entityType = this.Arguments[0];
        string result = string.Empty;

        if (entityType == nameof(Harvester))
        {
            result = this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else if (entityType == nameof(Provider))
        {
            result = this.providerController.Register(this.Arguments.Skip(1).ToList());
        }

        return result;
    }
}
