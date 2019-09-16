using Logger;
using System;
using System.IO;
using Task4_Parser.Models;
using Task4_Parser.Providers;
using Task4_Parser.Providers.Interfaces;

namespace Task4_Parser.Providers
{
    public class StreamReadWriteProvider : StreamReadProvider, IStreamReadWriteProvider
    {
        #region private fields

        private readonly string _copy = "_copy";
        private readonly string _backup = "_bak ";
        private readonly string patternDateTime = "MMddyyyyHHmmss";
        private string tempFile = String.Empty;
        private readonly string filePathOrigin = String.Empty;

        private readonly Stream _streamAccessWrite;
        private readonly StreamWriter _streamWriter;

        #endregion

        #region properties

        public StreamWriter StreamWriter { get => _streamWriter; }

        #endregion

        #region ctor

        public StreamReadWriteProvider(IInputArguments inputArguments,
                                  ILogger logger) : base(inputArguments, logger)
        {
            tempFile = CombineBufferFileName(inputArguments.FilePath, _copy
                                         + DateTime.Now.ToString(patternDateTime));
            filePathOrigin = inputArguments.FilePath;

            _streamAccessWrite = new FileStream(tempFile, FileMode.CreateNew,
                                              FileAccess.Write);
            _streamWriter = new StreamWriter(_streamAccessWrite);
        }

        #endregion

        public string CombineBufferFileName(string fileNamePath, string add)
        {
            var directory = Path.GetDirectoryName(fileNamePath);
            var ex = Path.GetExtension(fileNamePath);
            var name = Path.GetFileNameWithoutExtension(fileNamePath);
            var copyFile = Path.Combine(directory, name + add + ex);

            return copyFile;
        }

        private void ReplaceFiles()
        {
            _logger.Debug("FileStreamReplacer method ReplaceFiles " +
                                "was called.");

            if (File.Exists(filePathOrigin) && File.Exists(tempFile))
            {
                var backup = CombineBufferFileName(filePathOrigin,
                    _backup + DateTime.Now.ToString(patternDateTime));

                if (!File.Exists(backup))
                {
                    File.Move(filePathOrigin, backup);
                }

                File.Move(tempFile, filePathOrigin);
            }
        }

        public override void Dispose()
        {
            _logger.Debug("FileStreamReplacer method Dispose " +
                                 "was called.");

            if (_streamWriter != null)
            {
                _streamWriter.Flush();
                _streamWriter?.Close();
            }

            if (_streamAccessWrite != null)
            {
                _streamAccessWrite?.Close();
            }

            base.Dispose();

            ReplaceFiles();
        }
    }
}
