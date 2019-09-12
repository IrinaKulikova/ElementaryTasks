using Logger;
using Moq;
using Task4_Parser.Validators;

namespace Task4_Parser.Tests.IClassFixtures
{
    public class FakeArgumentsLengthValidator
    {
        private IValidator _argumentsLengthValidator;

        public IValidator ArgumentsLengthValidator
        {
            get => _argumentsLengthValidator;
        }

        public FakeArgumentsLengthValidator()
        {
            var mockLogger = new Mock<ILogger>();
            _argumentsLengthValidator = new ArgumentsLengthValidator(mockLogger.Object);
        }
    }
}
