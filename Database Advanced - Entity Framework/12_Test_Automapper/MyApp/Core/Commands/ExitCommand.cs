using System;
using MyApp.Core.Commands.Contracts;

namespace MyApp.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return "";
        }
    }
}
