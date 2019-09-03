using DIResolver;
using Logger;
using Task2_Envelopes.Containers;
using Task2_Envelopes.Containers.interfaces;
using Task2_Envelopes.Factories;
using Task2_Envelopes.Services.Interfaces;
using Task2_Envelopes.UI;

namespace Task2_Envelopes.Services
{
    public class Resolver : IResolver
    {
        public IApplication Configuration()
        {
            string logFile = "Task2_Envelopes.txt";
            ILogger logger = new SimpleLogger(logFile);

            IEnvelopeFactory envelopeFactory = new EnvelopeFactory();
            IParser parser = new Parser(envelopeFactory);
            IComparator comparator = new Comparator();
            IManager consoleManager = new ConsoleManager();
            IEnvelopeMapper envelopeMapper = new EnvelopeMapper(parser, logger);
            IValidator validatorArguments = new ValidatorArguments();
            IEnvelopeDTOFactory factoryEnvelopeDTO = new EnvelopeDTOFactory();
            IEnvelopeContainer envelopeContainer = new EnvelopesContainer(validatorArguments, envelopeMapper, factoryEnvelopeDTO);

            var application = new Application(comparator, consoleManager, logger,
                                              validatorArguments, envelopeContainer, envelopeMapper);

            return application;
        }
    }
}
