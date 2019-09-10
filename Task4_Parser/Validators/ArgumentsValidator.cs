using Logger;
using System.IO;

namespace Task4_Parser.Validators
{
    public class ArgumentsValidator : IArgumentsValidator
    {
        #region private fields

        private readonly IValidator _argumentLengthValidator;
        private readonly ILogger _logger;

        #endregion

        #region ctor

        public ArgumentsValidator(IValidator argumentLengthValidator,
                                  ILogger logger)
        {
            _argumentLengthValidator = argumentLengthValidator;
            _logger = logger;
        }

        #endregion

        public bool HasValidArguments(string[] args)
        {
            bool result = _argumentLengthValidator.IsValid(args)
                    && File.Exists(args[0]);

            _logger.Debug("ArgumentsValidator method IsValid returned "
                           + result);

            return result;
        }
    }
}
