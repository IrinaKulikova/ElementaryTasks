using Logger;
using Task4_Parser.Enums;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class ParserManager : IParserManager
    {
        #region private fields

        private readonly IFileSystemWorker _fileSystemWorker;
        private readonly ILogger _logger;

        #endregion

        #region ctor

        public ParserManager(IFileSystemWorker fileSystemWorker, ILogger logger)
        {
            _fileSystemWorker = fileSystemWorker;
            _logger = logger;
        }

        #endregion

        public IParser GetParser(ValidArgumentsLength validArgumentsLength)
        {

            switch (validArgumentsLength)
            {
                case ValidArgumentsLength.Empty:
                default:
                    _logger.Debug("There are invalid count arguments: " + validArgumentsLength);

                    //TODO: exception
                    return null;

                case ValidArgumentsLength.FileSearch:
                    return new ReaderParser(_logger);

                case ValidArgumentsLength.FileSearchReplace:
                    return new SwitcherParser(_fileSystemWorker, _logger);
            }

        }
    }
}
