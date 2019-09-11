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
            bool result = IsNotNull(arguments) && IsValidLength(arguments);

            _logger.Debug("ArgumentsLengthValidator method IsValid returned "
                           + result);

            return result;
        }

        private bool HasNullArguments(string[] arguments)
        {
            bool result = arguments == null || arguments.Length == 0;

            _logger.Debug("ArgumentsLengthValidator method HasNullArguments" +
                " returned " + result);

            return result;
        }

        private bool IsValidLength(string[] arguments)
        {
            bool result = Enum.IsDefined(typeof(ValidArgumentsLength), arguments.Length);

            _logger.Debug("ArgumentsLengthValidator method IsValidLength" +
                " returned " + result);

            return result;
        }

        private bool IsNotNull(string[] arguments)
        {
            bool result = !HasNullArguments(arguments);

            _logger.Debug("ArgumentsLengthValidator method IsNotNull" +
                " returned " + result);

            return result;
        }

    }
}
