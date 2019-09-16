using Logger;

namespace Task7_8_Sequence.Validators
{
    public class ArgumentsNotNullValidator : IValidator
    {
        #region private fields

        private readonly ILogger _logger;

        #endregion

        public ArgumentsNotNullValidator(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsValid(string[] arguments)
        {
            var result = arguments != null && arguments.Length != 0;

            _logger.Debug("ArgumentsNotNullValidator method IsValid " +
                          "returned: " + result);

            return result;
        }
    }
}
