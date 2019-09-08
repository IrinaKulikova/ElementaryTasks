using ApplicationInitializer;
using Logger;
using Task8_Fibonacci.Factories;
using Task8_Fibonacci.Providers;
using Task8_Fibonacci.UI;
using Task8_Fibonacci.Validators;

namespace Task8_Fibonacci.Services
{
    public class Initializer : IInitializer
    {
        public IApplication InitializeApplication()
        {
            string fileName = "Task8_Fibonacci_log.txt";
            var logger = new SimpleLogger(fileName);

            var argumentsValidator = new ArgumentsValidator();
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
