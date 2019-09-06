using DIResolver;
using Task4_Parser.Services;

namespace Task4_Parser
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
