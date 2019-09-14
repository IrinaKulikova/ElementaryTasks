using ApplicationInitializer;
using Logger;
using Task4_Parser.Factories;
using Task4_Parser.Providers;
using Task4_Parser.UI;
using Task4_Parser.Validators;

namespace Task4_Parser.Services
{
    public class Initializer : IInitializer
    {
        public IApplication InitializeApplication()
        {
            string fileName = "Task4_Parser_log.txt";
            var logger = new SimpleLogger(fileName);

            var argumentLengthValidator = new ArgumentsLengthValidator(logger);
            var argumentsValidator = new ArgumentsValidator(argumentLengthValidator,
                                                            logger);

            var inputArgumentsFactory = new InputArgumentsFactory(logger);
            var parseManager = new ParserManager(logger);

            var argumentsProvider = new ArgumentsProvider(argumentsValidator,
                                                          inputArgumentsFactory,
                                                          logger);

            var consileManager = new ConsoleManager();

            var app = new Application(argumentLengthValidator,
                                      argumentsProvider,
                                      parseManager,
                                      logger,
                                      consileManager);

            logger.Info("Application has been created.");

            return app;
        }
    }
}
