using System;
using System.IO;

namespace Logger
{
    public class SimpleLogger : ILogger
    {
        public string FileName { get; private set; }

        public SimpleLogger(string fileName)
        {
            FileName = fileName;
        }

        public void Info(string message)
        {
            WriteToFile(message, "info");
        }

        public void Warning(string message)
        {
            WriteToFile(message, "warning");
        }

        public void Error(string message)
        {
            WriteToFile(message, "error");
        }

        public void Debug(string message)
        {
            WriteToFile(message, "debug");
        }

        public void Error(Exception ex)
        {
            using (Stream stream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter stringStream = new StreamWriter(stream))
                {
                    stringStream.WriteLine(DateTime.Now.ToUniversalTime() +
                        "  |  " + "error exception" + "  |  " + ex.StackTrace);
                }
            }
        }

        private void WriteToFile(string message, string level)
        {
            using (Stream stream = new FileStream(FileName, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter stringStream = new StreamWriter(stream))
                {
                    stringStream.WriteLine(DateTime.Now.ToUniversalTime() + "  |  " + level + "  |  " + message);
                }
            }
        }
    }
}
