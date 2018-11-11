using System.Diagnostics;
using Shutdown_Timer.Core.Contracts;

namespace Shutdown_Timer.Core.Commands
{
    public class AbortCommand : ICommand
    {
        public string Execute()
        {
            Process.Start("shutdown", $"/a");
            return "Commnad abort successfully";
        }
    }
}
