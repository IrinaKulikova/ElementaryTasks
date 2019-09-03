using DIResolver;
using Logger;
using Task5_NumberWord.Factories;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Services.Interfaces;
using Task5_NumberWord.UI;

namespace Task5_NumberWord.Services
{
    public class Resolver : IResolver
    {
        public IApplication Configuration()
        {
            string logFile = "Task5_NumberWord_Log.txt";
            ILogger logger = new SimpleLogger(logFile);
            IArgumentsValidator argumentsValidator = new ArgumentsValidator();
            IDigitsFactory numerPartFactory = new DigitsFactory();
            IArgumentsFactory factoryArguments = new ArgumentsFactory();
            IManagerViews managerViews = new ManagerConsole();
            IManagerDictionary managerDictionary = new ManagerDictionary(numerPartFactory);
            INumberPartsCollectionFactory numberCollectionFactory = new NumberPartsCollectionFactory();

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
