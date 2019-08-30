using System;


namespace Logger
{
    public class SimpleLogger : ILogger
    {
        public string FileNmae { get; private set; }

        public SimpleLogger(string fileName)
        {
            FileNmae = fileName;
        }

        public void Error(Exception ex)
        {
            //throw new NotImplementedException();
        }

        public void Info(string message)
        {
            //throw new NotImplementedException();
        }

        public void Warging(string message)
        {
            //throw new NotImplementedException();
        }
    }
}
