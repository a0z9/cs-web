using System.Reflection.Metadata;

namespace WebApp_MVC_auth_jwt.Utils
{
    public class FileLogger : ILogger, IDisposable
    {
        private string filename;
        private LogLevel logLevelLimit;
        private object o = new object(); 

        public FileLogger(string filename, LogLevel logLevelLimit)
        {
            this.filename = filename;
            this.logLevelLimit = logLevelLimit;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => this;
       
        public void Dispose() {}

        public bool IsEnabled(LogLevel logLevel) => true; // logLevel >= logLevelLimit;
      
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string dateString = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.ffffff zzz: ");

            lock (o)
            File.AppendAllText(filename, $"{dateString} [{logLevel.ToString(),11}] {formatter(state, exception)}\n");

        }
    }
}
