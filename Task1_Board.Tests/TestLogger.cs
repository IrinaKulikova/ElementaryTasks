using System;
using Logger;

namespace Task1_Board.Tests
{
    public class TestLogger : ILogger
    {
        public void Debug(string message) { }
        public void Error(Exception exception) { }
        public void Error(string message) { }
        public void Info(string message) { }
        public void Warning(string message) { }
    }
}
