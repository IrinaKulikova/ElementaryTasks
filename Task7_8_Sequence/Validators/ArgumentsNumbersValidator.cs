using Logger;
using System;

namespace Task7_8_Sequence.Validators
{
    public class ArgumentsNumbersValidator : IValidator
    {
        #region private fields

        private readonly ILogger _logger;

        #endregion

        public ArgumentsNumbersValidator(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsValid(string[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                _logger.Error("ArgumentsNumbersValidator method IsValid " +
                          "returned false. Arguments are null or empty");

                return false;
            }

            for (int i = 0; i < arguments.Length; i++)
            {
                if (!(Int32.TryParse(arguments[i], out int buffer) && buffer >= 0))
                {
                    _logger.Error("ArgumentsNumbersValidator method IsValid " +
                         "returned false. Arguments are invalid!");

                    return false;
                }
            }

            _logger.Debug("ArgumentsNumbersValidator method IsValid " +
                      "returned true.");

            return true;
        }
    }
}
