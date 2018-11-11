using System;
using System.Linq;

namespace Shutdown_Timer.Core
{
    using Commands;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICommand command;

        public string Read(string[] inputArgs)
        {
            string action = inputArgs[0];
            inputArgs = inputArgs.Skip(1).ToArray();

            switch (action)
            {
                case "shutdown":
                    command = new ShutdownCommand(inputArgs);
                    break;
                case "restart":
                    command = new RestartCommand(inputArgs);
                    break;
                case "hibernate":
                    command = new HibernateCommand(inputArgs);
                    break;
                case "abort":
                    command = new AbortCommand();
                    break;
                case "exit":
                    command = new ExitCommand();
                    break;
                default:
                    throw new ArgumentNullException("Command is not supported!");
            }

            var result = command.Execute();
            return result;
        }
    }
}
