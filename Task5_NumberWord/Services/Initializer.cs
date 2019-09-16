using ApplicationInitializer;
using Logger;
using Task5_NumberWord.Factories;
using Task5_NumberWord.UI;

namespace Task5_NumberWord.Services
{
    public class Initializer : IInitializer
    {
        public IApplication InitializeApplication()
        {
            var logFile = "Task5_NumberWord_Log.txt";
            var logger = new SimpleLogger(logFile);

            var argumentsValidator = new ArgumentsValidator();
            var numerPartFactory = new DigitsFactory();
            var factoryArguments = new ArgumentsFactory();
            var managerViews = new ManagerConsole();
            var managerDictionary = new ManagerDictionary(numerPartFactory);
            var numberCollectionFactory = new NumberPartsCollectionFactory();

            var app = new Application(argumentsValidator,
                                      factoryArguments,
                                      numberCollectionFactory,
                                      managerDictionary,
                                      logger);

            app.AddObserver(managerViews);

            return app;
        }
    }
}
