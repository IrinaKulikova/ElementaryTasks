using DIResolver;
using System;
using Task5_NumberWord.Dictionaries;
using Task5_NumberWord.Expressions;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Services.Interfaces;

namespace Task5_NumberWord
{
    public class Application : IApplication
    {
        IValidator validator = null;
        AbstractDictionaryWords dictionary = null;
        INumberPartFactory numberFactory = null;

        public Application(IValidator validator, INumberPartFactory numberFactory)
        {
            this.validator = validator;
            this.numberFactory = numberFactory;
        }

        public void Start(string[] args)
        {
            if (!validator.IsNumber(args))
            {
                //Show instruction
            }

            Strategy(args);

            var context = new Context(args[0], dictionary);

            IExpression expression = new NonterminalExpression();
            expression.Interpret(context);

            context.Result.ForEach(s => Console.Write(s));
            Console.ReadKey();
        }

        private void Strategy(string[] args)
        {
            var lang = "EU";
            if (args.Length > 1)
            {
                lang = args[1];
            }

            switch (lang)
            {
                case "EU":
                default:

                    dictionary = new DictionaryWordsEU(numberFactory);
                    break;

            }
        }
    }
}
