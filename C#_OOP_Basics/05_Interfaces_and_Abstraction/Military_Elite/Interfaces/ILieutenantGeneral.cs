using System.Collections.Generic;

public interface ILieutenantGeneral : IPrivate
{
    IReadOnlyCollection<ISoldier> Privates { get; }
    void AddPrivate(ISoldier soldier);
}
