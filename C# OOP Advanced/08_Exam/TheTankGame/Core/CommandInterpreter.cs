using System.Linq;

namespace TheTankGame.Core
{
    using System.Collections.Generic;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters = inputParameters.Skip(1).ToList();

            var taskManagerMethods = this.tankManager
                .GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name.Contains(command));

            return (string)taskManagerMethods.Invoke(this.tankManager, new object[] { inputParameters });
        }
    }
}