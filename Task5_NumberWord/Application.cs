using DIResolver;
using Task5_NumberWord.Expressions;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Interfaces;
using Task5_NumberWord.UI;
using System.Collections.Generic;
using Task5_NumberWord.Factories;

namespace Task5_NumberWord
{
    public class Application : IApplication, IObservable
    {
        readonly IArgumentsFactory factoryArguments = null;
        INumberPartsCollectionFactory numberPartsCollectionFactory = null;
        readonly IManagerDictionary managerDictionary = null;
        IManagerViews managerViews = null;


        public Application(IArgumentsFactory factoryArguments,
                           INumberPartsCollectionFactory numberPartsCollectionFactory,
                           IManagerViews managerViews,
                           IManagerDictionary managerDictionary)
        {
            this.factoryArguments = factoryArguments;
            this.numberPartsCollectionFactory = numberPartsCollectionFactory;
            this.managerDictionary = managerDictionary;
            AddObserver(managerViews);
        }

        public void AddObserver(IManagerViews manager)
        {
            managerViews = manager;
        }

        public void NotifyShowInstruction() => managerViews.Instruction();

        public void NotifyShowNumberWords(List<string> words)
        {
            managerViews.Result(words);
        }

        public void Start(string[] args)
        {
            var arguments = factoryArguments.Create(args);

            if (arguments == null)
            {
                NotifyShowInstruction();
                return;
            }

            var dictionary = managerDictionary.GetDictionary(arguments.Language);
            var parts = numberPartsCollectionFactory.Parse(arguments.Number);

            var context = new Context(arguments.Number, dictionary, parts);

            IExpression expression = new NonterminalExpression();
            expression.Interpret(context);

            NotifyShowNumberWords(context.Result);
        }
    }
}
