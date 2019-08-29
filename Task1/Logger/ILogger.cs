using System;

namespace Task1.Logger
{
    public interface ILogger
    {
        void Info(string message);
        void Warging(string message);
        void Error(Exception exception);
    }
}
