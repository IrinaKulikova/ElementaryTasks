using Logger;
using Moq;
using Task7_8_Sequence.Validators;

namespace Task7_8_Sequence.Tests.IClassFixtures
{
    public class ArgumentsLengthValidatorFixture
    {
        private IValidator _argumentsLengthValidator;

        public IValidator ArgumentsLengthValidator
        {
            get => _argumentsLengthValidator;
        }

        public ArgumentsLengthValidatorFixture()
        {
            var mockLogger = new Mock<ILogger>();
            _argumentsLengthValidator = new ArgumentsLengthValidator
                                            (mockLogger.Object);
        }
    }
}
