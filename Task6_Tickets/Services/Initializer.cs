using ApplicationInitializer;
using Logger;
using Task6_Tickets.Factories;
using Task6_Tickets.Services.Interfaces;

namespace Task6_Tickets.Services
{
    public class Initializer : IInitializer
    {
        public IApplication InitializeApplication()
        {
            string fileName = "Task6_Tickets_log.txt";
            var logger = new SimpleLogger(fileName);

            var fileReader = new FileReader();
            var ticketFactory = new TicketFactory();
            var luckyTicketCounter = new LuckyTicketCounter(ticketFactory);
            var managerAlgorithm = new ManagerAlgorithm(logger);

            var app = new Application(fileReader, logger,
                                      luckyTicketCounter,
                                      managerAlgorithm);

            return app;
        }
    }
}
