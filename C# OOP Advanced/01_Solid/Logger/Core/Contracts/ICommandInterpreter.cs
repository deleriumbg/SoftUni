namespace Logger.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] args);

        void AddMessages(string[] args);

        void PrintInfo();
    }
}
