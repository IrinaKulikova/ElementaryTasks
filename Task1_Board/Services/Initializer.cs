using Task1_Board.Factories;
using Logger;
using ApplicationInitializer;

namespace Task1_Board.Services
{
    internal class Initializer : IInitializer
    {
        public IApplication InitializeApplication()
        {
            var logFile = "Task1_Board_Log.txt";
            var logger = new SimpleLogger(logFile);

            var cellFactory = new CellFactory();
            var boardFactory = new BoardFactory(cellFactory);
            var parser = new ArgumentsValidator(logger);
            var manager = new ControllerDictionary(boardFactory, logger);

            var app = new Application(parser, manager, logger);

            return app;
        }
    }
}
