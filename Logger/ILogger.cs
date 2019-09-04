using System;

namespace Logger
{
    public interface ILogger
    {
        void Debug(string message);
        void Info(string message);
        void Warning(string message);
        void Error(Exception exception);
        void Error(string message);
    }
}
