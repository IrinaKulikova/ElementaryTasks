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

        private readonly IValidatorArguments _validatorArguments;
        private readonly ILogger _logger;
        private readonly IArgumentsParser _argumentsParser;
        private readonly IComparer<IFigure> _comparer;

        #endregion

        #region ctor

        public Application(IValidatorArguments validatorArguments,
                           ILogger logger,
                           IArgumentsParser argumentsParser,
                           IComparer<IFigure> comparer)
        {
            _validatorArguments = validatorArguments;
            _logger = logger;
            _argumentsParser = argumentsParser;
            _comparer = comparer;
        }

        #endregion

        public void Start(string[] args)
        {
            if (!_validatorArguments.Check(args))
            {
                _logger.Warning("Invalid arguments: " + string.Join(", ", args));
                //Show Instructon
            }

            List<IFigure> figures = _argumentsParser.Figures(args);
            figures.Sort(_comparer);

            figures.ForEach(f => WriteLine(f.Name + " " + f.Square));
            ReadKey();
        }
    }
}