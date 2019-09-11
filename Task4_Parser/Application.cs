using ApplicationInitializer;
using Logger;
using System;
using Task4_Parser.Providers;
using Task4_Parser.Services.Interfaces;
using Task4_Parser.UI;
using Task4_Parser.Validators;

namespace Task4_Parser
{
    public delegate void Counter(int count);
    public delegate void Replacer();
    public delegate void EmptyOrErrorArguments();
    public delegate void InvalidArguments(string[] arguments);

    public class Application : IApplication
    {
        #region private fields

        private readonly IValidator _argumentsLengthValidator;
        private readonly IArgumentsProvider _argumentsProvider;
        private readonly IParserManager _parserManager;
        private readonly ILogger _logger;
        private readonly IManager _consoleManager;

        #endregion

        #region events

        public event InvalidArguments InvalidInputArguments;

        #endregion

        #region ctor

        public Application(IValidator argumentsLengthValidator,
                           IArgumentsProvider argumentsProvider,
                           IParserManager parserManager,
                           ILogger logger,
                           IManager consoleManager)
        {
            _argumentsLengthValidator = argumentsLengthValidator;
            _argumentsProvider = argumentsProvider;
            _parserManager = parserManager;
            _logger = logger;
            _consoleManager = consoleManager;
        }

        #endregion

        #region private methods Subscribe, Unsubscribe events

        private void SubscribeEvents()
        {
            _parserManager.CountResult += _consoleManager.ShowCount;
            _parserManager.ReplaceResult += _consoleManager.ShowReplacedDone;
            _parserManager.InvalidArguments += _consoleManager.ShowInstructon;
            InvalidInputArguments += _consoleManager.InvalidInputArguments;
        }


        private void UnsubscribeEvents()
        {
            _parserManager.CountResult -= _consoleManager.ShowCount;
            _parserManager.ReplaceResult -= _consoleManager.ShowReplacedDone;
            _parserManager.InvalidArguments -= _consoleManager.ShowInstructon;
            InvalidInputArguments += _consoleManager.InvalidInputArguments;
        }

        #endregion

        public void Start(string[] args)
        {
            _logger.Info("Application method Start was called with arguments: "
                       + String.Join(", ", args));

            var arguments = _argumentsProvider.GetArguments(args);
            SubscribeEvents();

            if (arguments == null)
            {
                _logger.Error("Invalid arguments: " + String.Join(", ", args));
                InvalidInputArguments?.Invoke(args);
                UnsubscribeEvents();

                return;
            }

            _parserManager.Parse(arguments);
            UnsubscribeEvents();
        }
    }
}