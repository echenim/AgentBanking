using System;
using log4net;

namespace Echenim.Nine.Util.Audit.Logic
{
    public static class Log4NetHelper
    {
        private static bool _isConfigured;


        private static void EnsureConfigured()
        {
            if (!_isConfigured)
            {
                log4net.Config.XmlConfigurator.Configure();
                _isConfigured = true;
            }
        }


        private static ILog GetLogger(string name)
        {
            EnsureConfigured();
            return LogManager.GetLogger(name);
        }


        public static void Log(string message, LogLevel logLevel, string entityFormalNamePlural, int entityKeyValue, string userName, Exception exception)
        {
            ILog logger = GetLogger(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

            GlobalContext.Properties["EntityFormalNamePlural"] = !String.IsNullOrWhiteSpace(entityFormalNamePlural) ? entityFormalNamePlural : String.Empty;
            GlobalContext.Properties["EntityKeyValue"] = entityKeyValue;
            GlobalContext.Properties["UserName"] = !String.IsNullOrWhiteSpace(userName) ? userName : String.Empty;

            if (exception != null)
                message = exception.Message;

            switch (logLevel)
            {
                case LogLevel.INFO:
                    logger.Info(message, exception);
                    break;

                case LogLevel.Debug:
                    logger.Debug(message, exception);
                    break;

                case LogLevel.WARN:
                    logger.Warn(message, exception);
                    break;

                case LogLevel.ERROR:
                    logger.Error(message, exception);
                    break;

                case LogLevel.FATAL:
                    logger.Fatal(message, exception);
                    break;
            }
        }
    }


    public enum LogLevel
    {
        Debug,
        INFO,
        WARN,
        ERROR,
        FATAL
    }


}
