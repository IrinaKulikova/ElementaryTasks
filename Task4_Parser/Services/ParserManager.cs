using Logger;
using Task4_Parser.Enums;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class ParserManager : IParserManager
    {
        #region private fields

        private readonly IFileSystemWorker fileSystemWorker = null;
        private readonly ILogger logger = null;

        #endregion

        public ParserManager(IFileSystemWorker fileSystemWorker, ILogger logger)
        {
            this.fileSystemWorker = fileSystemWorker;
            this.logger = logger;
        }

        public IParser GetParser(ValidArgumentsLength validArgumentsLength)
        {

            switch (validArgumentsLength)
            {
                case ValidArgumentsLength.Empty:
                default:
                    logger.Debug("There are invalid count arguments: " + validArgumentsLength);
                    return null;

                case ValidArgumentsLength.FileSearch:
                    return new ReaderParser(logger);

                case ValidArgumentsLength.FileSearchReplace:
                    return new SwitcherParser(fileSystemWorker, logger);
            }

        }
    }
}
