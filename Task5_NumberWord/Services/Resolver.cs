using DIResolver;
using Task5_NumberWord.Factories;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Services.Interfaces;

namespace Task5_NumberWord.Services
{
    public class Resolver : IResolver
    {
        public IApplication Build()
        {
            IValidator validator = new Validator();
            INumberPartFactory numerPartFactory = new NumberPartFactory();
            var app = new Application(validator, numerPartFactory);

            return app;
        }
    }
}
