using Logger;
using System;
using System.Collections.Generic;
using System.IO;
using Task4_Parser.Models;

namespace Task4_Parser.Services
{
    public class FileStreamCounter : IDisposable
    {
        #region private fields

        private readonly Stream streamAccessRead;
        private readonly StreamReader streamReader;

        #endregion

        #region protected fields

        protected readonly ILogger _logger;

        #endregion

        #region ctor

        public FileStreamCounter(IInputArguments inputArguments,
                                  ILogger logger)
        {
            streamAccessRead = new FileStream(inputArguments.FilePath, FileMode.Open, FileAccess.Read);
            streamReader = new StreamReader(streamAccessRead);
            _logger = logger;
        }

        #endregion

        public IEnumerable<string> GetLine()
        {
            string line = String.Empty;

            int countDebug = 0;

            do
            {
                line = streamReader.ReadLine();

                if (line != null)
                {
                    _logger.Debug("FileStreamCounter method GetLine " +
                                  "returned " + line);

                    countDebug++;

                    yield return line;
                }

            } while (line != null);
        }

        public virtual void Dispose()
        {
            _logger.Debug("FileStreamCounter method Dispose " +
                                 "was called.");

            streamReader.Close();
            streamAccessRead.Close();
        }
    }
}