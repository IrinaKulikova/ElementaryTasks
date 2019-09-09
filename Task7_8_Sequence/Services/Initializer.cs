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
            string fileName = "Task8_Fibonacci_log.txt";
            var logger = new SimpleLogger(fileName);

            var validatorList = new List<IValidator>()
            {
                new ArgumentsNotNullValidator(),
                new ArgumentsLengthValidator(),
                new ArgumentsNumbersValidator()
            };

            var argumentsValidator = new ArgumentsValidator(validatorList);
            var sequenceLimitsFactory = new SequenceLimitFactory();
            var consoleManager = new ConsoleManager();

            var argumentsProvider = new ArgumentsProvider(argumentsValidator,
                                                        sequenceLimitsFactory);


            var app = new Application(argumentsProvider, logger,
                                      consoleManager);

            return app;
        }
    }
}
