using System;

namespace RmLogger
{
    public static class LogManager
    {
        public static ILog GetLogger(Type type)
        {
            return new RmLog(type);
        }
    }
}