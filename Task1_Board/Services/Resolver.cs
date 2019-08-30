using Task1_Board.Factories;
using Task1_Board.Services.Interfaces;
using Logger;
using DIResolver;

namespace Task1_Board.Services
{
    internal class Resolver : IResolver
    {
        public IApplication Build()
        {
            string logFile = "Task1_Board_Log.txt";
            IBoardFactory boardFactory = new BoardFactory();
            IParser parser = new Parser();
            IRouter router = new Router(boardFactory);
            ILogger logger = new SimpleLogger(logFile);

            var app = new Application(parser, router, logger);

            return app;
        }
    }
}
