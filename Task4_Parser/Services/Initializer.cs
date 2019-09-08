using ApplicationInitializer;
using Logger;
using Task4_Parser.Factories;

namespace Task4_Parser.Services
{
    public class Initializer : IInitializer
    {
        public IApplication InitializeApplication()
        {
            string fileName = "Task4_Parser_log.txt";
            var logger = new SimpleLogger(fileName);

            var argumentsValidator = new ArgumentsValidator();
            var fileSystemWorker = new FileSystemWorker();
            var parserManager = new ParserManager(fileSystemWorker, logger);
            var parseArgumentsFactory = new ParseArgumentsFactory(logger);

            var app = new Application(argumentsValidator, parserManager, 
                                      logger, parseArgumentsFactory);

            return app;
        }
    }
}
