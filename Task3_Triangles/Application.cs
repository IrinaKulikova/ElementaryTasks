using DIResolver;
using Logger;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using Task3_Triangles.Models;
using Task3_Triangles.Services.Interfaces;

namespace Task3_Triangles
{
    public class Application : IApplication
    {
        readonly IValidatorArguments validatorArguments = null;
        readonly ILogger logger = null;
        readonly IArgumentsParser argumentsParser = null;
        readonly IComparer<IFigure> comparer = null;

        public Application(IValidatorArguments validatorArguments,
                           ILogger logger,
                           IArgumentsParser argumentsParser,
                           IComparer<IFigure> comparer)
        {
            this.validatorArguments = validatorArguments;
            this.logger = logger;
            this.argumentsParser = argumentsParser;
            this.comparer = comparer;
        }

        public void Start(string[] args)
        {
            if (!validatorArguments.Check(args))
            {
                logger.Warning("Invalid arguments: " + string.Join(", ", args));
                //Show Instructon
            }

            List<IFigure> figures = argumentsParser.Figures(args);
            figures.Sort(comparer);

            figures.ForEach(f => WriteLine(f.Square));
            ReadKey();
        }
    }
}