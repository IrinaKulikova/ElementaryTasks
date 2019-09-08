using System;
using Logger;
using Task4_Parser.Enums;
using Task4_Parser.Factories.Interfaces;
using Task4_Parser.Models;

namespace Task4_Parser.Factories
{
    public class InputArgumentsFactory : IInputArgumentsFactory
    {
        #region private fields

        private readonly ILogger _logger;

        #endregion

        #region ctor

        public InputArgumentsFactory(ILogger logger)
        {
            _logger = logger;
        }

        #endregion

        public IInputArguments Create(string[] arguments)
        {
            var filePath = arguments[0];
            var searchText = arguments[1];
            string newText = null;
            var argumentsLength = ValidArgumentsLength.FileSearchReplace;

            try
            {
                newText = arguments[2];
            }
            catch (IndexOutOfRangeException)
            {
                argumentsLength = ValidArgumentsLength.FileSearch;
                _logger.Info("arguments: " + String.Join(", ", arguments));
            }

            return new InputArguments(filePath, searchText, newText, argumentsLength);
        }
    }
}
