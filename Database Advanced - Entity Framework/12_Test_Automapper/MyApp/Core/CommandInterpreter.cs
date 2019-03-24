using System;
using System.Linq;
using System.Reflection;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.Contracts;

namespace MyApp.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";
        private readonly IServiceProvider provider;

        public CommandInterpreter(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public string Read(string[] args)
        {
            string command = $"{args[0]}{CommandSuffix}";

            Type type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == command);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            string[] commandParams = args
                .Skip(1)
                .ToArray();

            ConstructorInfo constructor = type.GetConstructors()[0];

            var constructorParams = constructor
                .GetParameters()
                .Select(x => x.ParameterType)
                .Select(x => this.provider.GetService(x))
                .ToArray();

            ICommand commandInstance = (ICommand)constructor
                .Invoke(constructorParams);

            return commandInstance.Execute(commandParams);
        }
    }
}
