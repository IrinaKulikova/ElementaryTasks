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
        private readonly BufferedStream bufferedStream;
        private readonly StreamReader streamReader;

        #endregion

        public FileStreamCounter(IInputArguments inputArguments)
        {
            streamAccessRead = new FileStream(inputArguments.FilePath, FileMode.Open, FileAccess.Read);
            bufferedStream = new BufferedStream(streamAccessRead);
            streamReader = new StreamReader(bufferedStream);
        }


        public List<string> GetText()
        {
            List<string> textLines = new List<string>();

            string line = String.Empty;
            do
            {
                line = streamReader.ReadLine();

                if (line != null)
                {
                    textLines.Add(line);
                }

            } while (line != null);

            return textLines;
        }

        public virtual void Dispose()
        {
            streamReader.Close();
            bufferedStream.Close();
            streamAccessRead.Close();
        }
    }
}