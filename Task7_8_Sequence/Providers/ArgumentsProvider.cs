using Task7_8_Sequence.Factories;
using Task7_8_Sequence.Models;
using Task7_8_Sequence.Validators;

namespace Task7_8_Sequence.Providers
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

            if (_argumentsValidator.HasValidArguments(arguments))
            {
                sequenceLimit = _sequenceLimitsFactory.Create(arguments);
            }

            return sequenceLimit;
        }
    }
}
