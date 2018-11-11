using System;
using System.Diagnostics;
using Shutdown_Timer.Core.Contracts;

namespace Shutdown_Timer.Core.Commands
{
    public class RestartCommand : ICommand
    {
        private readonly string[] inputArgs;

        public RestartCommand(string[] inputArgs)
        {
            this.inputArgs = inputArgs;
        }

        public string Execute()
        {
            if (inputArgs.Length < 1 || string.IsNullOrEmpty(inputArgs[0]))
            {
                throw new ArgumentNullException("Parameters count mismatch!");
            }

            int minutes = int.Parse(inputArgs[0]);
            int seconds = minutes * 60;

            Process.Start("shutdown", $"/r /t {seconds}");

            return $"Windows will restart afeter {minutes}m.";
        }
    }
}
