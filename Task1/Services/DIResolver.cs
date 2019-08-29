using Task1.Factories;
using Task1.Logger;
using Task1.Services.Interfaces;
using Task1_Board;
using Task1_Board.Services;
using Task1_Board.Services.Interfaces;

namespace Task1.Services
{
    internal class DIResolver : IDIResolver
    {
        public Application Build()
        {
            string logFile = "log.txt";
            IBoardFactory boardFactory = new BoardFactory();
            IParser parser = new Parser();
            IRouter router = new Router(boardFactory);
            ILogger logger = new SimpleLogger(logFile);

            var app = new Application(parser, router, logger);

            return app;
        }
    }
}
