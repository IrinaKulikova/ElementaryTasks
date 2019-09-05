using DIResolver;
using Task6_Tickets.Services;

namespace Task6_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            IResolver resolver = new Resolver();
            IApplication app = resolver.Initialization();
            app.Start(args);
        }
    }
}
