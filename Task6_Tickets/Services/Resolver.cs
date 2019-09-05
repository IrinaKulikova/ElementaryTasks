using DIResolver;

namespace Task6_Tickets.Services
{
    public class Resolver : IResolver
    {
        public IApplication Initialization()
        {
            IApplication app = new Application();

            return app;
        }
    }
}
