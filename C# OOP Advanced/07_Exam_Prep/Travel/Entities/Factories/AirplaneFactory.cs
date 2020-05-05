using System;
using System.Linq;
using System.Reflection;

namespace Travel.Entities.Factories
{
    using Contracts;
    using Airplanes.Contracts;

    public class AirplaneFactory : IAirplaneFactory
    {
        public IAirplane CreateAirplane(string typeName)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);
            IAirplane airplane = (IAirplane)Activator.CreateInstance(type);
            return airplane;
        }
    }
}