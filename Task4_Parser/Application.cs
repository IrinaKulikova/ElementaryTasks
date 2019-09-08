using ApplicationInitializer;
using CustomCollections;
using Logger;
using System;
using Task4_Parser.Enums;
using Task4_Parser.Factories.Interfaces;
using Task4_Parser.Models;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser
{
    public class Application : IApplication
    {
        #region private fields

        private readonly IArgumentsValidator _argumentsValidator;
        private readonly IParserManager _parserManager;
        private readonly ILogger _logger;
        private readonly IParseArgumentsFactory _parseArgumentsFactory;

        #endregion

        #region ctor

        public Application(IArgumentsValidator argumentsValidator,
                           IParserManager parserManager,
                           ILogger logger,
                           IParseArgumentsFactory parseArgumentsFactory)
        {
            _argumentsValidator = argumentsValidator;
            _parserManager = parserManager;
            _logger = logger;
            _parseArgumentsFactory = parseArgumentsFactory;
        }

        #endregion

        public void Start(string[] args)
        {
            if (!_argumentsValidator.Check(args))
            {
                _logger.Warning("Invalid arguments: " + string.Join(", ", args));
            }

            if (_argumentsValidator.Check(args))
            {
                var argumentsCollection = new ArgumentCollection<string>(args);
                var parser = _parserManager.GetParser((ValidArgumentsLength)argumentsCollection.Count);
                var parseArguments = _parseArgumentsFactory.Create(argumentsCollection);
                int count = parser.RunText(parseArguments);

                Console.WriteLine(count);
                Console.ReadKey();
            }
            else
            {
                _logger.Warning("End of program. Invalid arguments twice " + string.Join(", ", args));
            }
        }
    }
}