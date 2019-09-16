using ApplicationInitializer;
using Logger;
using Task3_Triangles.Factories;

namespace Task3_Triangles.Services
{
    public class Initializer : IInitializer
    {
        public IApplication InitializeApplication()
        {
            var fileName = "Task3_Triangles_log.txt";
            var logger = new SimpleLogger(fileName);

            var validatorArguments = new ValidatorArguments();
            var figureFactory = new TriangleFactory();
            var argumentsParser = new ArgumentsParser(figureFactory);
            var comparer = new TriangleSorter();

            var app = new Application(validatorArguments, logger,
                                               argumentsParser, comparer);

            return app;
        }
    }
}