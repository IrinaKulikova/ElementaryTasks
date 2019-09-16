using Logger;
using System;
using Task7_8_Sequence.Enums;
using Task7_8_Sequence.Models;

namespace Task7_8_Sequence.Factories
{
    public class SequenceLimitFactory : ISequenceLimitFactory
    {
        #region private fields

        private readonly ILogger _logger;

        #endregion

        #region ctor

        public SequenceLimitFactory(ILogger logger)
        {
            _logger = logger;
        }

        #endregion

        public ISequenceLimit Create(string[] limits)
        {
            if (limits == null || limits.Length > (int)CountArguments.TwoLimits)
            {
                return null;
            }

            int min = 0;
            int max = 0;

            Int32.TryParse(limits[0], out min);

            if ((CountArguments)limits.Length > CountArguments.OneLimit)
            {
                Int32.TryParse(limits[1], out max);
            }

            var sequenceLimits = (min < max) ? new SequenceLimit(min, max) :
                                            new SequenceLimit(max, min);
            var log = $"SequenceLimit instance was created with fields:" +
                         $"Min: {sequenceLimits.Min}, Max {sequenceLimits.Max} ";

            _logger.Debug(log);

            return sequenceLimits;
        }
    }
}
