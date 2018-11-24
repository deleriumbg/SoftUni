namespace Logger.Loggers
{
    using Contracts;
    using Appenders.Contracts;
    using Enums;

    public class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender): this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }

        public void Error(string dateTime, string errorMessage)
        {
            AppendMessage(dateTime, ReportLevel.ERROR, errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            AppendMessage(dateTime, ReportLevel.INFO, infoMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            AppendMessage(dateTime, ReportLevel.FATAL, fatalMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            AppendMessage(dateTime, ReportLevel.CRITICAL, criticalMessage);
        }

        public void Warning(string dateTime, string warningMessage)
        {
            AppendMessage(dateTime, ReportLevel.WARNING, warningMessage);
        }

        private void AppendMessage(string dateTime, ReportLevel reportLevel, string errorMessage)
        {
            this.fileAppender?.Append(dateTime, reportLevel, errorMessage);
            this.consoleAppender?.Append(dateTime, reportLevel, errorMessage);
        }
    }
}
