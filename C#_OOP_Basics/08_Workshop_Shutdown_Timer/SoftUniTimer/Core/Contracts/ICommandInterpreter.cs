namespace Shutdown_Timer.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] inputArgs);
    }
}
