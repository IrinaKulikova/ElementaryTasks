using Task4_Parser.Models;

namespace Task4_Parser.Services.Interfaces
{
    public interface IFileSystemWorker
    {
        void ReplaceFiles(string filePath, string copyFilePath);
        string CombineBufferFileName(string filePath);
    }
}
