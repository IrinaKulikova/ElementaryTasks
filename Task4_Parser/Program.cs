using Task4_Parser.Services;

namespace Task4_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new Initializer();
            var app = initializer.InitializeApplication();
            app.Start(args);
        }
    }
}
