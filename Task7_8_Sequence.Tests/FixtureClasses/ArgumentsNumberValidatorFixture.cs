using Logger;
using Moq;
using Task7_8_Sequence.Validators;

namespace Task7_8_Sequence.Tests.IClassFixtures
{
    public class ArgumentsNumberValidatorFixture
    {
        private IValidator _argumentsNumberValidator;

        public IValidator ArgumentsNumberValidator
        {
            get => _argumentsNumberValidator;
        }

        public ArgumentsNumberValidatorFixture()
        {
            var mockLogger = new Mock<ILogger>();
            _argumentsNumberValidator = new ArgumentsNumbersValidator
                                            (mockLogger.Object);
        }
    }
}
