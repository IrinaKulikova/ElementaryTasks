using Logger;
using Task7_8_Sequence.Enums;

namespace Task7_8_Sequence.Validators
{
    public class ArgumentsLengthValidator : IValidator
    {
        #region private fields

        private readonly ILogger _logger;

        #endregion

        public ArgumentsLengthValidator(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsValid(string[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                _logger.Error("Arguments are null or empty. " +
                    "class ArgumentsLengthValidator method IsValid " +
                    "returned false");

                return false;
            }

            return HasOneLimit(arguments) || HasTwoLimit(arguments);
        }


        private bool HasOneLimit(string[] arguments)
        {
            bool result = CountArguments.OneLimit ==
                   (CountArguments)arguments.Length;

            _logger.Debug("ArgumentsLengthValidator method HasOneLimit" +
                " returned " + result);

            return result;
        }

        private bool HasTwoLimit(string[] arguments)
        {
            bool result = CountArguments.TwoLimits ==
                   (CountArguments)arguments.Length;

            _logger.Debug("ArgumentsLengthValidator method HasTwoLimit" +
               " returned " + result);

            return result;
        }
    }
}
