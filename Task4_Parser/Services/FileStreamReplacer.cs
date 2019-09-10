using Logger;
using System;
using System.IO;
using Task4_Parser.Models;

namespace Task4_Parser.Services
{
    public class FileStreamReplacer : FileStreamCounter
    {
        #region private fields

        private readonly string _copy = "_copy";
        private readonly string _backup = "_bak ";
        private readonly string patternDateTime = "MMddyyyyHHmmss";
        private string tempFile = String.Empty;
        private readonly string filePathOrigin = String.Empty;

        private readonly Stream streamAccessWrite;
        private readonly StreamWriter streamWriter;

        #endregion

        #region ctor

        public FileStreamReplacer(IInputArguments inputArguments,
                                  ILogger logger) : base(inputArguments, logger)
        {
            tempFile = CombineBufferFileName(inputArguments.FilePath, _copy
                                         + DateTime.Now.ToString(patternDateTime));
            filePathOrigin = inputArguments.FilePath;

            streamAccessWrite = new FileStream(tempFile, FileMode.CreateNew,
                                              FileAccess.Write);
            streamWriter = new StreamWriter(streamAccessWrite);
        }

        #endregion

        public void SetText(string line)
        {
            streamWriter.WriteLine(line);
        }

        private string CombineBufferFileName(string fileNamePath, string add)
        {
            string directory = Path.GetDirectoryName(fileNamePath);
            string ex = Path.GetExtension(fileNamePath);
            string name = Path.GetFileNameWithoutExtension(fileNamePath);
            string copyFile = Path.Combine(directory, name + add + ex);

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

            streamWriter.Flush();

            streamWriter.Close();
            streamAccessWrite.Close();

            base.Dispose();

            ReplaceFiles();
        }
    }
}
