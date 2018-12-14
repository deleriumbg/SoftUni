using System;
using System.Linq;
using System.Reflection;

namespace Travel.Entities.Factories
{
    using Contracts;
    using Items.Contracts;

    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(string typeName)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);
            IItem item = (IItem)Activator.CreateInstance(type);
            return item;
        }
    }
}
