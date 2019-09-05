using DIResolver;
using Logger;
using Task6_Tickets.Services.Interfaces;

namespace Task6_Tickets.Services
{
    public class Resolver : IResolver
    {
        public IApplication Initialization()
        {
            IFileReader fileReader = new FileReader();
            string fileName = "Task6_Tickets_log.txt";
            ILogger logger = new SimpleLogger(fileName);
            IApplication app = new Application(fileReader, logger);

            return app;
        }
    }
}
