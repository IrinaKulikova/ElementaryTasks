using DIResolver;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Interfaces;
using Task5_NumberWord.UI;
using System.Collections.Generic;
using Task5_NumberWord.Factories;
using Task5_NumberWord.Services.Interfaces;
using Logger;
using Task5_NumberWord.Dictionaries;
using Task5_NumberWord.Models;
using Task5_NumberWord.Services;

namespace Task5_NumberWord
{
    public class Application : IApplication, IObservable
    {
        #region private fields

        private readonly IArgumentsFactory factoryArguments = null;
        private readonly IArgumentsValidator argumentsValidator = null;
        private readonly IManagerDictionary managerDictionary = null;
        private readonly ILogger logger = null;
        private readonly INumberPartsCollectionFactory numberPartsCollectionFactory = null;

        private IManagerViews managerViews = null;

        #endregion

        public Application(IArgumentsValidator argumentsValidator,
                           IArgumentsFactory factoryArguments,
                           INumberPartsCollectionFactory numberPartsCollectionFactory,
                           IManagerDictionary managerDictionary,
                           ILogger logger)
        {
            this.factoryArguments = factoryArguments;
            this.numberPartsCollectionFactory = numberPartsCollectionFactory;
            this.managerDictionary = managerDictionary;
            this.argumentsValidator = argumentsValidator;
            this.logger = logger;
        }

        public void AddObserver(IManagerViews manager)
        {
            managerViews = manager;
        }

        public void NotifyShowInstruction()
        {
            managerViews?.Instruction();
        }

        public void NotifyShowNumberWords(string words)
        {
            managerViews?.ShowResultWords(words);
        }

        public void Start(string[] args)
        {
            if (!argumentsValidator.Check(args))
            {
                NotifyShowInstruction();
                logger.Warning("invalid arguments: " + string.Join(", ", args));
                return;
            }

            Arguments arguments = factoryArguments.Create(args);

            AbstractDictionaryWords dictionary = managerDictionary.GetDictionary(arguments.Language);
            Queue<NumberPart> numberParts = numberPartsCollectionFactory.Parse(arguments.Number);

            IConverterNumber converter = new ConverterNumber(dictionary, numberParts);
            string words = converter.GetWord();

            NotifyShowNumberWords(words);
        }
    }
}