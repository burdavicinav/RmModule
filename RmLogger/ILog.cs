using System;

namespace RmLogger
{
    public enum LogLevel { Information, Debug, Warning, Error };

    public interface ILog
    {
        void Write(string log, int? user, LogLevel lvl = LogLevel.Error);

        void Info(string log, int? user);

        void Debug(string log, int? user);

        void Warning(string log, int? user);

        void Error(string log, int? user);

        void IsDebugEnabled(bool value);
    }
}
