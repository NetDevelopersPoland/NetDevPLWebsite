using System;

namespace NetDevPL.Infrastructure.SharedKernel
{
    public static class Logger
    {
        static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        
        public static void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public static void Fatal(Exception excepion)
        {
            logger.Fatal(excepion);
        }

        public static void Info(string message)
        {
            logger.Info(message);
        }

        public static void Debug(string message)
        {
            logger.Debug(message);
        }

        public static void Warning(string message)
        {
            logger.Warn(message);
        }
    }
}
