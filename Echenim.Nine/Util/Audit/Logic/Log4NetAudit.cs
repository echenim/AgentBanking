using System;
using log4net;

namespace Echenim.Nine.Util.Audit.Logic
{
    public class Log4NetAudit
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

       public static void FailureAudit(string originator, Rank ranking, string username, string datakey, string message,Exception exception)
       {
           var origin = !string.IsNullOrEmpty(originator) ? originator : string.Empty;

            ILog logger = GetLogger(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            GlobalContext.Properties["Originator"] = $"{username.Replace(".", " ")}";
            GlobalContext.Properties["Reason"] = $" Attempted to    {origin}";
            GlobalContext.Properties["DataKey"] = !string.IsNullOrEmpty(datakey) ? datakey : string.Empty;
           // GlobalContext.Properties["UserName"] = !string.IsNullOrEmpty(username) ? username : string.Empty;
            if (exception != null)
                message = exception.Message;

            switch (ranking)
            {
                case Rank.INFO:
                    logger.Info(message, exception);
                    break;

                case Rank.Debug:
                    logger.Debug(message, exception);
                    break;

                case Rank.WARN:
                    logger.Warn(message, exception);
                    break;

                case Rank.ERROR:
                    logger.Error(message, exception);
                    break;

                case Rank.FATAL:
                    logger.Fatal(message, exception);
                    break;
            }
        }
        public static void FailureAudit(string originator, Rank ranking, string datakey, string message, Exception exception)
        {
            var origin = !string.IsNullOrEmpty(originator) ? originator : string.Empty;

            ILog logger = GetLogger(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            GlobalContext.Properties["Originator"] = origin;
            GlobalContext.Properties["DataKey"] = !string.IsNullOrEmpty(datakey) ? datakey : string.Empty;
            // GlobalContext.Properties["UserName"] = !string.IsNullOrEmpty(username) ? username : string.Empty;
            if (exception != null)
                message = exception.Message;

            switch (ranking)
            {
                case Rank.INFO:
                    logger.Info(message, exception);
                    break;

                case Rank.Debug:
                    logger.Debug(message, exception);
                    break;

                case Rank.WARN:
                    logger.Warn(message, exception);
                    break;

                case Rank.ERROR:
                    logger.Error(message, exception);
                    break;

                case Rank.FATAL:
                    logger.Fatal(message, exception);
                    break;
            }
        }

     
        public static void SuccessAudit(string originator, Rank ranking, string username, string datakey, string message)
        {
            var origin = !string.IsNullOrEmpty(originator) ? originator : string.Empty;

            ILog logger = GetLogger(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            GlobalContext.Properties["Originator"] = $"{username.Replace(".", " ")}";
            GlobalContext.Properties["Reason"] = $" Attempted to    {origin}";
            GlobalContext.Properties["DataKey"] = !string.IsNullOrEmpty(datakey) ? datakey : string.Empty;
            // GlobalContext.Properties["UserName"] = !string.IsNullOrEmpty(username) ? username : string.Empty;

            switch (ranking)
            {
                case Rank.SUCCESS:
                    logger.Info(message);
                    break;

               
            }
        }

        public enum Rank
        {
            Debug,
            INFO,
            WARN,
            ERROR,
            FATAL,
            SUCCESS
        }
    }

}
