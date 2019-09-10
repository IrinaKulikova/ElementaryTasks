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
            var argumentsLength = (ValidArgumentsLength)arguments.Length;

            if ((ValidArgumentsLength)arguments.Length
                    == ValidArgumentsLength.FileSearchReplace)
            {
                newText = arguments[2];
            }

            _logger.Info($@"InputArguments was created with fields: 
                           filePath: {filePath}, searchText: 
                           {searchText}, newText: {newText},
                            argumentsLength: {argumentsLength}");

            return new InputArguments(filePath, searchText, newText,
                argumentsLength);
        }
    }
}
