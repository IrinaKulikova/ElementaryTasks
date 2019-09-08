using CustomCollections;
using Logger;
using Task1_Board.Enums;
using Task1_Board.Services.Interfaces;

namespace Task1_Board.Services
{
    public class ArgumentsValidator : IArgumentsValidator
    {
        #region private fields

        private readonly ILogger _logger;

        #endregion

        public ArgumentsValidator(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsValidInputArguments(string[] inputArguments, IArgumentCollection<int> argumets)
        {

            foreach (var argument in inputArguments)
            {
                if (int.TryParse(argument, out int currentArgument) && currentArgument > 0)
                {
                    argumets.Add(currentArgument);
                }
                else
                {
                    _logger.Error($"Invalid argument: {argument}");
                    return false;
                }

            }

            return IsValidLength(argumets);
        }

        private bool IsValidLength(IArgumentCollection<int> argumets)
        {
            return argumets.Count == (int)CountArgument.Necessary;
        }
    }
}