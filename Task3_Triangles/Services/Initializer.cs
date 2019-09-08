using ApplicationInitializer;
using Logger;
using System.Collections.Generic;
using Task3_Triangles.Factories;
using Task3_Triangles.Models;
using Task3_Triangles.Services.Interfaces;

namespace Task3_Triangles.Services
{
    public class Initializer : IInitializer
    {
        public IApplication InitializeApplication()
        {
            string fileName = "Task3_Triangles_log.txt";
            ILogger logger = new SimpleLogger(fileName);

            IValidatorArguments validatorArguments = new ValidatorArguments();
            IFigureFactory figureFactory = new TriangleFactory();
            IArgumentsParser argumentsParser = new ArgumentsParser(figureFactory);
            IComparer<IFigure> comparer = new TriangleSorter();

            IApplication app = new Application(validatorArguments, logger,
                                               argumentsParser, comparer);

            return app;
        }
    }
}