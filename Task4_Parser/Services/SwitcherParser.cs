using Logger;
using System.IO;
using Task4_Parser.Models;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class SwitcherParser : IParser
    {
        #region

        readonly IFileSystemWorker fileSystemWorker = null;
        readonly ILogger logger = null;

        #endregion

        public SwitcherParser(IFileSystemWorker fileSystemWorker,
                              ILogger logger)
        {
            this.fileSystemWorker = fileSystemWorker;
            this.logger = logger;
        }

        public int RunText(IParseArguments parseArguments)
        {
            int count = 0;
            int bufferSize = parseArguments.SearchText.Length * 100;

            string copyFilePath = fileSystemWorker.CombineBufferFileName(parseArguments.FilePath);

            try
            {

                using (Stream streamOrigin = new FileStream(parseArguments.FilePath, FileMode.Open, FileAccess.Read))
                {
                    using (Stream streamNew = new FileStream(copyFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        byte[] buf = new byte[bufferSize];

                        using (StreamReader sr = new StreamReader(streamOrigin))
                        {
                            using (StreamWriter sw = new StreamWriter(streamNew))
                            {
                                char[] dataArray = new char[bufferSize];

                                while (sr.Peek() >= 0)
                                {
                                    sr.Read(dataArray, 0, dataArray.Length);
                                    string origin = new string(dataArray);
                                    int index = 0;

                                    while ((index = new string(dataArray).IndexOf(parseArguments.SearchText, index)) != -1)
                                    {
                                        index += parseArguments.SearchText.Length;
                                        count++;
                                    }

                                    string newText = origin.Replace(parseArguments.SearchText, parseArguments.NewText);
                                    sw.Write(newText);
                                }
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                logger.Error(ex);
            }

            fileSystemWorker.ReplaceFiles(parseArguments.FilePath, copyFilePath);

            return count;
        }
    }
}