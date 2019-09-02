using DIResolver;

namespace Task4_Parser.Services
{
    public class Resolver : IResolver
    {
        public IApplication Build()
        {
            var app = new Application();

            return app;
        }
    }
}
