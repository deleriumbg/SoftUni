namespace Logger.Appenders
{
    using System;
    using System.IO;
    using Logger.Layouts.Contracts;
    using Logger.Loggers.Contracts;
    using Loggers.Enums;

    public class FileAppender : Appender
    {
        private const string filePath = "log.txt";
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            this.MessagesCount++;
            string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
            this.logFile.Write(content);
            File.AppendAllText(filePath, content);
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}, File size: {this.logFile.Size}";
        }
    }
}
