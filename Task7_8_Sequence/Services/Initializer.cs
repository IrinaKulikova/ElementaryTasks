using ApplicationInitializer;
using Logger;
using System.Collections.Generic;
using Task7_8_Sequence.Factories;
using Task7_8_Sequence.Providers;
using Task7_8_Sequence.UI;
using Task7_8_Sequence.Validators;

namespace Task7_8_Sequence.Services
{
    public class Initializer : IInitializer
    {
        public IApplication InitializeApplication()
        {
            var fileName = "Task7_8_Sequence_log.txt";
            var logger = new SimpleLogger(fileName);

            var validatorList = new List<IValidator>()
            {
                new ArgumentsNotNullValidator(logger),
                new ArgumentsLengthValidator(logger),
                new ArgumentsNumbersValidator(logger)
            };

            var argumentsValidator = new ArgumentsValidator(validatorList,
                                                            logger);
            var sequenceLimitsFactory = new SequenceLimitFactory(logger);
            var consoleManager = new ConsoleManager();

            var argumentsProvider = new ArgumentsProvider(argumentsValidator,
                                                        sequenceLimitsFactory,
                                                        logger);


            var app = new Application(argumentsProvider, logger,
                                      consoleManager);

            logger.Info("Application is initialized");

            return app;
        }
    }
}
