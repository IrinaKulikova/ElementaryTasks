using System;
using ApplicationInitializer;
using Logger;
using Task8_Fibonacci.Collections;
using Task8_Fibonacci.Providers;
using Task8_Fibonacci.UI;

namespace Task8_Fibonacci
{
    public class Application : IApplication
    {
        #region privte fields

        private readonly IArgumentsProvider _argumentsProvider;
        private readonly ILogger _logger;
        private readonly IManager _consoleManager;

        #endregion

        #region ctor

        public Application(IArgumentsProvider argumentsProvider,
                           ILogger logger,
                           IManager consoleManager)
        {
            _argumentsProvider = argumentsProvider;
            _logger = logger;
            _consoleManager = consoleManager;
        }

        #endregion

        public void Start(string[] args)
        {
            var sequenceLimits = _argumentsProvider.GetLimits(args);

            if (sequenceLimits == null)
            {
                _logger.Error("Invalid arguments: " + String.Join(", ", args));
                _consoleManager.ShowInstruction();
                return;
            }

            var sequence = new SquareSequence(sequenceLimits);
            _consoleManager.ShowResult(sequence);
        }
    }
}