using Microsoft.AspNetCore.Routing.Constraints;

namespace WebApp_MVC_auth_jwt.Utils
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private string filename;
        private LogLevel logLevelLimit;
        public FileLoggerProvider(string filename, LogLevel logLevelLimit)
        {
            this.filename = filename;
            this.logLevelLimit = logLevelLimit;
        }

        public FileLoggerProvider() : this("info.log", LogLevel.Information) { }

        public ILogger CreateLogger(string categoryName) => new FileLogger(filename, logLevelLimit);
       

        public void Dispose() { }
    }
}
