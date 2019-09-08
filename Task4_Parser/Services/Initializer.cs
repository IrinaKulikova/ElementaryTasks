using ApplicationInitializer;
using Logger;
using Task4_Parser.Dictionaries;
using Task4_Parser.Factories;
using Task4_Parser.Providers;
using Task4_Parser.Validators;

namespace Task4_Parser.Services
{
    public class Initializer : IInitializer
    {
        public IApplication InitializeApplication()
        {
            string fileName = "Task4_Parser_log.txt";
            var logger = new SimpleLogger(fileName);

            var argumentLengthValidator = new ArgumentsLengthValidator();
            var argumentsValidator = new ArgumentsValidator(argumentLengthValidator);
            var inputArgumentsFactory = new InputArgumentsFactory(logger);
            var dictionaryParse = new ParserDictionary();

            var argumentsProvider = new ArgumentsProvider(argumentsValidator,
                                                          inputArgumentsFactory,
                                                          logger);


            var app = new Application(argumentLengthValidator,
                                      argumentsProvider,
                                      dictionaryParse,
                                      logger);

            return app;
        }
    }
}
