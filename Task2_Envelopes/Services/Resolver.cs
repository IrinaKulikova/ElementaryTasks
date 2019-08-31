using DIResolver;
using Logger;
using Task2_Envelopes.Factories;
using Task2_Envelopes.Services.Interfaces;
using Task2_Envelopes.UI;

namespace Task2_Envelopes.Services
{
    public class Resolver : IResolver
    {
        public IApplication Build()
        {
            string logFile = "Task1_Board_Log.txt";
            ILogger logger = new SimpleLogger(logFile);

            IEnvelopeFactory envelopeFactory = new EnvelopeFactory();
            IParser parser = new Parser(envelopeFactory);
            IComparator comparator = new Comparator();
            IManager consoleManager = new ConsoleManager();
            IEnvelopeMapper envelopeMapper = new EnvelopeMapper(parser, logger);
            IValidator validatorArguments = new ValidatorArguments();
            IFactoryEnvelopeDTO factoryEnvelopeDTO = new FactoryEnvelopeDTO();

            var application = new Application(comparator, consoleManager, logger, envelopeMapper,
                                              validatorArguments, factoryEnvelopeDTO);

            return application;
        }
    }
}
