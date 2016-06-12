using System;

namespace NetDevPLWeb.SharedKernel
{
    public static class Logger
    {
        public static void Fatal(string message)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            logger.Fatal(message);
        }

        public static void Fatal(Exception excepion)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            logger.Fatal(excepion);
        }

        public static void Info(string message)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            logger.Info(message);
        }

        public static void Debug(string message)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            logger.Debug(message);
        }

        public static void Warning(string message)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            logger.Warn(message);
        }
    }
}