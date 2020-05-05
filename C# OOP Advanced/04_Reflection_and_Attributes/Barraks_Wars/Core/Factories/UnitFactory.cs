namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type unitTypeName = Type.GetType("_03BarracksFactory.Models.Units." + unitType);
            IUnit unit = (IUnit) Activator.CreateInstance(unitTypeName);
            return unit;
        }
    }
}
