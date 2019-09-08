using Logger;
using static System.Console;
using System.Collections.Generic;
using Task3_Triangles.Models;
using Task3_Triangles.Services.Interfaces;
using ApplicationInitializer;

namespace Task3_Triangles
{
    public class Application : IApplication
    {
        #region private fields

        private readonly IValidatorArguments validatorArguments = null;
        private readonly ILogger logger = null;
        private readonly IArgumentsParser argumentsParser = null;
        private readonly IComparer<IFigure> comparer = null;

        #endregion

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

            figures.ForEach(f => WriteLine(f.Name + " " + f.Square));
            ReadKey();
        }
    }
}