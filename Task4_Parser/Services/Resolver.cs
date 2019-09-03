using DIResolver;
using Logger;
using Task4_Parser.Factories;
using Task4_Parser.Factories.Interfaces;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class Resolver : IResolver
    {
        public IApplication Build()
        {
            string fileName = "Task4_Parser_log.txt";
            ILogger logger = new SimpleLogger(fileName);

            IArgumentsValidator argumentsValidator = new ArgumentsValidator();
            IParserManager parserManager = new ParserManager();
            IParseArgumentsFactory parseArgumentsFactory = new ParseArgumentsFactory();

            var app = new Application(argumentsValidator, parserManager, logger, parseArgumentsFactory);

            return app;
        }
    }
}
