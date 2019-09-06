using DIResolver;
using Task1_Board.Services;

namespace Task1_Board
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
