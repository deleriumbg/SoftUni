using System;
using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;

	public class SetFactory : ISetFactory
	{
	    public ISet CreateSet(string name, string typeName)
	    {
	        Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);
	        ISet set = (ISet) Activator.CreateInstance(type, name);
	        return set;
	    }
	}
}
