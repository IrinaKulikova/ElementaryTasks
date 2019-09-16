using Logger;
using System;
using Task4_Parser.Enums;

namespace Task4_Parser.Validators
{
    public class ArgumentsLengthValidator : IValidator
    {
        #region private fields

        private readonly ILogger _logger;

        #endregion

        #region ctor

        public ArgumentsLengthValidator(ILogger logger)
        {
            _logger = logger;
        }

        #endregion

        public bool IsValid(string[] arguments)
        {
            var result = IsNotNull(arguments) && IsValidLength(arguments);

            _logger.Debug("ArgumentsLengthValidator method IsValid returned "
                           + result);

            return result;
        }

        private bool HasNullArguments(string[] arguments)
        {
            var result = arguments == null || arguments.Length == 0;

            _logger.Debug("ArgumentsLengthValidator method HasNullArguments" +
                " returned " + result);

            return result;
        }

        private bool IsValidLength(string[] arguments)
        {
            var result = Enum.IsDefined(typeof(ValidArgumentsLength), arguments.Length);

            _logger.Debug("ArgumentsLengthValidator method IsValidLength" +
                " returned " + result);

            return result;
        }

        private bool IsNotNull(string[] arguments)
        {
            var result = !HasNullArguments(arguments);

            _logger.Debug("ArgumentsLengthValidator method IsNotNull" +
                " returned " + result);

            return result;
        }
    }
}
