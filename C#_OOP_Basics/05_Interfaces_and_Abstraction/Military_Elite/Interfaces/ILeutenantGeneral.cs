using System.Collections.Generic;

public interface ILeutenantGeneral : IPrivate
{
    IReadOnlyCollection<ISoldier> Privates { get; }
    void AddPrivate(ISoldier soldier);
}
