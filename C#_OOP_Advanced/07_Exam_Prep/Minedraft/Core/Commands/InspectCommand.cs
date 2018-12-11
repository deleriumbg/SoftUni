using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        int id = int.Parse(this.Arguments[0]);
        IEntity entity = this.harvesterController.Entities.FirstOrDefault(e => e.ID == id) ?? 
                         this.providerController.Entities.FirstOrDefault(e => e.ID == id);

        if (entity == null)
        {
            return string.Format(Constants.EntityNotFound, id);
        }

        return entity.ToString();
    }
}
