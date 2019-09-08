﻿using System.IO;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class FileSystemWorker : IFileSystemWorker
    {
        #region private fields

        private readonly string _copy = "_copy";

        #endregion

        public string CombineBufferFileName(string fileNamePath)
        {
            string directory = Path.GetDirectoryName(fileNamePath);
            string ex = Path.GetExtension(fileNamePath);
            string name = Path.GetFileNameWithoutExtension(fileNamePath);
            string copyFile = Path.Combine(directory, name + _copy + ex);

            return copyFile;
        }

        public void ReplaceFiles(string filePath, string copyFilePath)
        {

            if (File.Exists(filePath) && File.Exists(copyFilePath))
            {
                File.Delete(filePath);
                File.Move(copyFilePath, filePath);
            }

        }
    }
}