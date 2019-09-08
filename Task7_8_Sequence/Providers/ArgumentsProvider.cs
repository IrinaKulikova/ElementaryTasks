using Task8_Fibonacci.Factories;
using Task8_Fibonacci.Models;
using Task8_Fibonacci.Validators;

namespace Task8_Fibonacci.Providers
{
    public class ArgumentsProvider : IArgumentsProvider
    {
        #region private fields

        private readonly IArgumentsValidator _argumentsValidator;
        private readonly ISequenceLimitFactory _sequenceLimitsFactory;

        #endregion

        #region ctor

        public ArgumentsProvider(IArgumentsValidator argumentsValidator,
                                 ISequenceLimitFactory sequenceLimitsFactory)
        {
            _argumentsValidator = argumentsValidator;
            _sequenceLimitsFactory = sequenceLimitsFactory;
        }

        #endregion

        public ISequenceLimit GetLimits(string[] arguments)
        {
            ISequenceLimit sequenceLimit = null;

            if (_argumentsValidator.HasTwoArguments(arguments) &&
                _argumentsValidator.HasNumbers(arguments))
            {
                sequenceLimit = _sequenceLimitsFactory.Create(arguments);
            }

            return sequenceLimit;
        }
    }
}
