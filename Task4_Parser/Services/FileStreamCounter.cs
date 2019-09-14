using Logger;
using System;
using System.IO;
using Task4_Parser.Models;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class FileStreamCounter : IFileStreamCounter, IDisposable
    {
        #region private fields

        private readonly Stream _streamAccessRead;
        private readonly StreamReader _streamReader;

        #endregion

        #region protected fields

        protected readonly ILogger _logger;

        #endregion

        #region properies

        public StreamReader StreamReader { get => _streamReader; }

        #endregion

        #region ctor

        public FileStreamCounter(IInputArguments inputArguments,
                                  ILogger logger)
        {
            _streamAccessRead = new FileStream(inputArguments.FilePath, FileMode.Open, FileAccess.Read);
            _streamReader = new StreamReader(_streamAccessRead);
            _logger = logger;
        }

        #endregion

        public virtual void Dispose()
        {
            _logger.Debug("FileStreamCounter method Dispose " +
                                 "was called.");


            if (_streamReader != null)
            {
                _streamReader?.Close();
            }

            if (_streamAccessRead != null)
            {
                _streamAccessRead?.Close();
            }
        }
    }
}