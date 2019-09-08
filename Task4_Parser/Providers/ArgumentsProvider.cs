using Logger;
using System;
using Task4_Parser.Factories.Interfaces;
using Task4_Parser.Models;
using Task4_Parser.Validators;

namespace Task4_Parser.Providers
{
    public class ArgumentsProvider : IArgumentsProvider
    {
        #region private properties

        private readonly IArgumentsValidator _argumentsValidator;
        private readonly IInputArgumentsFactory _inputArgumentsFactory;
        private readonly ILogger _logger;

        #endregion

        #region ctor

        public ArgumentsProvider(IArgumentsValidator argumentsValidator,
                                 IInputArgumentsFactory inputArgumentsFactory,
                                 ILogger logger)
        {
            _argumentsValidator = argumentsValidator;
            _inputArgumentsFactory = inputArgumentsFactory;
            _logger = logger;
        }

        #endregion

        public IInputArguments GetArguments(string[] arguments)
        {

            if (!_argumentsValidator.HasValidArguments(arguments))
            {
                string message = "Arguments are invalid! " +
                    String.Join(", ", arguments);

                _logger.Error(message);

                throw new ArgumentException(message);
            }

            return _inputArgumentsFactory.Create(arguments);
        }
    }
}
