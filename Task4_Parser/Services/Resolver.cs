using DIResolver;
using Logger;
using Task4_Parser.Factories;
using Task4_Parser.Factories.Interfaces;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class Resolver : IResolver
    {
        public IApplication Initialization()
        {
            string fileName = "Task4_Parser_log.txt";
            ILogger logger = new SimpleLogger(fileName);

            IArgumentsValidator argumentsValidator = new ArgumentsValidator();
            IFileSystemWorker fileSystemWorker = new FileSystemWorker();
            IParserManager parserManager = new ParserManager(fileSystemWorker, logger);
            IParseArgumentsFactory parseArgumentsFactory = new ParseArgumentsFactory(logger);

            var app = new Application(argumentsValidator, parserManager, logger, parseArgumentsFactory);

            return app;
        }
    }
}
