using Logger;
using System.IO;
using Task4_Parser.Models;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class ReaderParser : IParser
    {
        readonly ILogger logger = null;

        public ReaderParser(ILogger logger)
        {
            this.logger = logger;
        }

        public int RunText(ParseArguments arguments)
        {
            int count = 0;
            int bufferSize = arguments.SearchText.Length * 100;

            try
            {
                using (Stream stream = new FileStream(arguments.FilePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        char[] dataArray = new char[bufferSize];
                        while (sr.Peek() >= 0)
                        {
                            sr.Read(dataArray, 0, dataArray.Length);
                            int index = 0;

                            while ((index = new string(dataArray).IndexOf(arguments.SearchText, index)) != -1)
                            {
                                index += arguments.SearchText.Length;
                                count++;
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                logger.Error(ex);
            }

            return count;
        }
    }
}