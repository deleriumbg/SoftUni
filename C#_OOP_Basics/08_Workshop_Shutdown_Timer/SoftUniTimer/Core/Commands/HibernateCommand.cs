using System;
using System.Diagnostics;
using Shutdown_Timer.Core.Contracts;

namespace Shutdown_Timer.Core.Commands
{
    public class HibernateCommand : ICommand
    {
        private readonly string[] inputArgs;

        public HibernateCommand(string[] inputArgs)
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

            Process.Start("shutdown", $"/h /t {seconds}");

            return $"Windows will hibernate afeter {minutes}m.";
        }
    }
}
