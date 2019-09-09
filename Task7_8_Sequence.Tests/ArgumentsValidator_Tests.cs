using Logger;
using Moq;
using System.Collections.Generic;
using Task7_8_Sequence.Validators;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsValidator_Tests
    {
        [Theory]
        [InlineData("3", "9")]
        [InlineData("39", "9")]
        [InlineData("9")]
        public void IsValid_Success(params string[] arguments)
        {
            ArgumentsValidator argumentsValidator = GetValidator();

            var result = argumentsValidator.HasValidArguments(arguments);

            Assert.True(result);
        }

        [Theory]
        [InlineData("3", "9", "999")]
        [InlineData()]
        public void IsValid_Fail(params string[] arguments)
        {
            ArgumentsValidator argumentsValidator = GetValidator();

            var result = argumentsValidator.HasValidArguments(arguments);

            Assert.False(result);
        }

        private static ArgumentsValidator GetValidator()
        {
            var mockLogger = new Mock<ILogger>();

            var validatorList = new List<IValidator>()
            {
                new ArgumentsNotNullValidator(mockLogger.Object),
                new ArgumentsLengthValidator(mockLogger.Object),
                new ArgumentsNumbersValidator(mockLogger.Object)
            };

            var argumentsValidator = new ArgumentsValidator(validatorList,
                                                            mockLogger.Object);
            return argumentsValidator;
        }
    }
}
