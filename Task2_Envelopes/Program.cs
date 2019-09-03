using DIResolver;
using Task2_Envelopes.Services;

namespace Task2_Envelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            IResolver resolver = new Resolver();
            IApplication app = resolver.Configuration();
            app.Start(args);
        }
    }
}
