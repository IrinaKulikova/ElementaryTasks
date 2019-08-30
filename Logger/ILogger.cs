using System;

namespace Logger
{
    public interface ILogger
    {
        void Info(string message);
        void Warging(string message);
        void Error(Exception exception);
    }
}
