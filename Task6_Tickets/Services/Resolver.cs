using DIResolver;
using Logger;
using Task6_Tickets.Factories;
using Task6_Tickets.Services.Interfaces;

namespace Task6_Tickets.Services
{
    public class Resolver : IResolver
    {
        public IApplication Initialization()
        {
            string fileName = "Task6_Tickets_log.txt";
            ILogger logger = new SimpleLogger(fileName);
            IFileReader fileReader = new FileReader();
            ITicketFactory ticketFactory = new TicketFactory();
            ILuckyTicketCounter luckyTicketCounter = new LuckyTicketCounter(ticketFactory);
            IManagerAlgorithm managerAlgorithm = new ManagerAlgorithm(logger);

            IApplication app = new Application(fileReader, logger,
                                               luckyTicketCounter,
                                               managerAlgorithm);

            return app;
        }
    }
}
