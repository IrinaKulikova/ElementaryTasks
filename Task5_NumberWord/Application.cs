using DIResolver;
using Task5_NumberWord.Expressions;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Interfaces;
using Task5_NumberWord.UI;
using System.Collections.Generic;
using Task5_NumberWord.Factories;
using Task5_NumberWord.Services.Interfaces;

namespace Task5_NumberWord
{
    public class Application : IApplication, IObservable
    {
        readonly IArgumentsFactory factoryArguments = null;
        readonly IArgumentsValidator argumentsValidator = null;
        readonly IManagerDictionary managerDictionary = null;

        INumberPartsCollectionFactory numberPartsCollectionFactory = null;
        IManagerViews managerViews = null;


        public Application(IArgumentsValidator argumentsValidator,
                           IArgumentsFactory factoryArguments,
                           INumberPartsCollectionFactory numberPartsCollectionFactory,
                           IManagerDictionary managerDictionary)
        {
            this.factoryArguments = factoryArguments;
            this.numberPartsCollectionFactory = numberPartsCollectionFactory;
            this.managerDictionary = managerDictionary;
            this.argumentsValidator = argumentsValidator;
        }

        public void AddObserver(IManagerViews manager)
        {
            managerViews = manager;
        }

        public void NotifyShowInstruction()
        {
            managerViews?.Instruction();
        }

        public void NotifyShowNumberWords(List<string> words)
        {
            managerViews?.Result(words);
        }

        public void Start(string[] args)
        {
            if (!argumentsValidator.Check(args))
            {
                NotifyShowInstruction();
                return;
            }

            var arguments = factoryArguments.Create(args);           

            var dictionary = managerDictionary.GetDictionary(arguments.Language);
            var context = new Context(dictionary, arguments.Number);

            IExpression expression = new NonterminalExpression(numberPartsCollectionFactory);
            expression.Interpret(context);

            NotifyShowNumberWords(context.Result);
        }
    }
}
