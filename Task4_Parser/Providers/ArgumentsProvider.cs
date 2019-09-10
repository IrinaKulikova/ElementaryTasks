using Logger;
using System;
using Task4_Parser.Factories.Interfaces;
using Task4_Parser.Models;
using Task4_Parser.Validators;

namespace Task4_Parser.Providers
{
    public class ArgumentsProvider : IArgumentsProvider
    {
        #region private fields

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
            _logger.Debug("ArgumentsProvider method GetArguments was called.");

            IInputArguments inputArguments = null;

            if (!_argumentsValidator.HasValidArguments(arguments))
            {
                _logger.Error("Arguments are invalid! " +
                    String.Join(", ", arguments));

                return inputArguments;
            }

            inputArguments = _inputArgumentsFactory.Create(arguments);

            _logger.Info("Arguments were created:  " +
                    String.Join(", ", arguments));

            return inputArguments;
        }
    }
}
