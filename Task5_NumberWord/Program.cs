using DIResolver;
using Task5_NumberWord.Services;

namespace Task5_NumberWord
{
    class Program
    {
        static void Main(string[] args)
        {
            IResolver resolver = new Resolver();
            resolver.Build().Start(args);
        }
    }
}
