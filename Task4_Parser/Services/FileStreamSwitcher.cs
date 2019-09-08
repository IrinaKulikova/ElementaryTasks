using System;
using System.Collections.Generic;
using System.IO;
using Task4_Parser.Models;

namespace Task4_Parser.Services
{
    public class FileStreamSwitcher : FileStreamCounter
    {
        private readonly string _copy = "_copy";
        private string tempFile = String.Empty;
        private readonly string filePathOrigin = String.Empty;

        private readonly Stream streamAccessWrite;
        private readonly BufferedStream bufferedStream;
        private readonly StreamWriter streamWriter;


        public FileStreamSwitcher(IInputArguments inputArguments) : base(inputArguments)
        {
            tempFile = CombineBufferFileName(inputArguments.FilePath);
            filePathOrigin = inputArguments.FilePath;

            streamAccessWrite = new FileStream(tempFile, FileMode.CreateNew, FileAccess.Write);
            bufferedStream = new BufferedStream(streamAccessWrite);
            streamWriter = new StreamWriter(bufferedStream);
        }

        public void SetText(List<string> lines, IInputArguments inputArguments)
        {
            foreach (var line in lines)
            {
                streamWriter.WriteLine(line);
            }

            streamWriter.Flush();
        }


        public string CombineBufferFileName(string fileNamePath)
        {
            string directory = Path.GetDirectoryName(fileNamePath);
            string ex = Path.GetExtension(fileNamePath);
            string name = Path.GetFileNameWithoutExtension(fileNamePath);
            string copyFile = Path.Combine(directory, name + _copy + ex);

            return copyFile;
        }

        public void ReplaceFiles()
        {
            if (File.Exists(filePathOrigin) && File.Exists(tempFile))
            {
                File.Delete(filePathOrigin);
                File.Move(tempFile, filePathOrigin);
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            streamAccessWrite.Close();
            bufferedStream.Close();
            streamAccessWrite.Close();

            ReplaceFiles();
        }
    }
}
