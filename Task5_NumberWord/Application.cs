using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Interfaces;
using Task5_NumberWord.UI;
using Task5_NumberWord.Factories;
using Task5_NumberWord.Services.Interfaces;
using Logger;
using Task5_NumberWord.Services;
using ApplicationInitializer;

namespace Task5_NumberWord
{
    public class Application : IApplication, IObservable
    {
        #region private fields

        private readonly IArgumentsFactory _factoryArguments;
        private readonly IArgumentsValidator _argumentsValidator;
        private readonly IManagerDictionary _managerDictionary;
        private readonly ILogger _logger;
        private readonly INumberPartsCollectionFactory _numberPartsCollectionFactory;

        private IManagerViews _managerViews;

        #endregion

        #region ctor

        public Application(IArgumentsValidator argumentsValidator,
                           IArgumentsFactory factoryArguments,
                           INumberPartsCollectionFactory numberPartsCollectionFactory,
                           IManagerDictionary managerDictionary,
                           ILogger logger)
        {
            _factoryArguments = factoryArguments;
            _numberPartsCollectionFactory = numberPartsCollectionFactory;
            _managerDictionary = managerDictionary;
            _argumentsValidator = argumentsValidator;
            _logger = logger;
        }

        #endregion

        public void AddObserver(IManagerViews manager)
        {
            _managerViews = manager;
        }

        public void NotifyShowInstruction()
        {
            _managerViews?.Instruction();
        }

        public void NotifyShowNumberWords(string words)
        {
            _managerViews?.ShowResultWords(words);
        }

        public void Start(string[] args)
        {
            if (!_argumentsValidator.Check(args))
            {
                NotifyShowInstruction();
                _logger.Warning("invalid arguments: " + string.Join(", ", args));
                return;
            }

            var arguments = _factoryArguments.Create(args);

            var dictionary = _managerDictionary.GetDictionary(arguments.Language);
            var numberParts = _numberPartsCollectionFactory.Parse(arguments.Number);

            var converter = new ConverterNumber(dictionary, numberParts);
            string words = converter.GetWord();

            NotifyShowNumberWords(words);
        }
    }
}