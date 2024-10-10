namespace WebApp_MVC_auth_jwt.Utils
{
    public static class LoggingBuilderExtension
    {
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, 
            string filename= "info.log", LogLevel limit = LogLevel.Trace)
        {
         builder.AddProvider(new FileLoggerProvider(filename, limit));
            return builder;
        
        }
    }
}
