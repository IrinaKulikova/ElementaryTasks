using Logger;
using System.Collections.Generic;

namespace Task7_8_Sequence.Validators
{
    public class ArgumentsValidator : IArgumentsValidator
    {
        #region private fields

        private readonly IEnumerable<IValidator> _validatorsList;
        private readonly ILogger _logger;

        #endregion

        #region ctor

        public ArgumentsValidator(IEnumerable<IValidator> validatorsList,
                                  ILogger logger)
        {
            _validatorsList = validatorsList;
            _logger = logger;
        }

        #endregion

        public bool HasValidArguments(string[] args)
        {
            _logger.Info("ArgumentsValidator method HasValidArguments" +
                          " was called.");

            foreach (var validator in _validatorsList)
            {
                if (!validator.IsValid(args))
                {
                    _logger.Error("ArgumentsValidator method HasValidArguments" +
                                  "returned false. Arguments are invalid!");

                    return false;
                }
            }

            _logger.Debug("ArgumentsValidator method HasValidArguments" +
                                 "returned true.");
            return true;
        }
    }
}
