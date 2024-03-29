﻿using System;
using ApplicationInitializer;
using Logger;
using Task7_8_Sequence.Sequences;
using Task7_8_Sequence.Providers;
using Task7_8_Sequence.UI;

namespace Task7_8_Sequence
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
            string inputArguments = args == null ? String.Empty :
                                            String.Join(", ", args);

            _logger.Info("Application method Start was called with arguments: "
                        + inputArguments);

            var sequenceLimits = _argumentsProvider.GetLimits(args);

            if (sequenceLimits == null)
            {
                _logger.Error("Invalid arguments: " + inputArguments);
                _consoleManager.ShowInstruction();

                return;
            }

            var sequence = new FibonacciSequence(sequenceLimits);

            _logger.Debug("FibonacciSequence: " + String.Join(", ", sequence));

            _consoleManager.ShowResult(sequence);
        }
    }
}