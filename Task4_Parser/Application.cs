using ApplicationInitializer;
using Logger;
using System;
using Task4_Parser.Dictionaries;
using Task4_Parser.Enums;
using Task4_Parser.Models;
using Task4_Parser.Providers;
using Task4_Parser.Services;
using Task4_Parser.Services.Interfaces;
using Task4_Parser.Validators;

namespace Task4_Parser
{
    public class Application : IApplication
    {
        #region private fields

        private readonly IArgumentsLengthValidator _argumentsLengthValidator;
        private readonly IArgumentsProvider _argumentsProvider;
        private readonly IParserDictionary _parserDictionary;
        private readonly ILogger _logger;

        #endregion

        #region ctor

        public Application(IArgumentsLengthValidator argumentsLengthValidator,
                           IArgumentsProvider argumentsProvider,
                           IParserDictionary parserDictionary,
                           ILogger logger)
        {
            _argumentsLengthValidator = argumentsLengthValidator;
            _argumentsProvider = argumentsProvider;
            _parserDictionary = parserDictionary;
            _logger = logger;
        }

        #endregion

        public void Start(string[] args)
        {
            IInputArguments arguments = null;

            if (!_argumentsLengthValidator.HasValidLength(args))
            {
                //Get args
            }

            try
            {
                arguments = _argumentsProvider.GetArguments(args);
            }
            catch (ArgumentException ex)
            {
                _logger.Error("Invalid arguments: " + string.Join(", ", args)
                               + " " + ex.StackTrace);
                //Show message
                return;
            }

            int count = _parserDictionary.GetCount(arguments);

            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}