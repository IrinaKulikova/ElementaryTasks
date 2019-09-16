using ApplicationInitializer;
using Logger;
using Task2_Envelopes.Containers;
using Task2_Envelopes.Factories;
using Task2_Envelopes.UI;

namespace Task2_Envelopes.Services
{
    public class Initializer : IInitializer
    {
        public IApplication InitializeApplication()
        {
            var logFile = "Task2_Envelopes_log.txt";
            var logger = new SimpleLogger(logFile);

            var envelopeFactory = new EnvelopeFactory();
            var parser = new Parser(envelopeFactory);
            var comparator = new Comparator();
            var consoleManager = new ConsoleManager();
            var envelopeMapper = new EnvelopeMapper(parser, logger);
            var validatorArguments = new ValidatorArguments();
            var factoryEnvelopeDTO = new EnvelopeDTOFactory();
            var envelopeContainer = new EnvelopesContainer(validatorArguments,
                                                            envelopeMapper,
                                                            factoryEnvelopeDTO);

            var application = new Application(comparator, consoleManager, 
                                              logger, validatorArguments,
                                              envelopeContainer, 
                                              envelopeMapper);

            return application;
        }
    }
}
