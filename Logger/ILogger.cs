using System;

namespace Logger
{
    public interface ILogger
    {
        void Info(string message);
        void Warning(string message);
        void Error(Exception exception);
    }
}
