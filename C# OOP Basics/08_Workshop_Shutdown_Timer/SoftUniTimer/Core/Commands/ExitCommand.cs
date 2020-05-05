using System;
using Shutdown_Timer.Core.Contracts;

namespace Shutdown_Timer.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute()
        {
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
            return null;
        }
    }
}
