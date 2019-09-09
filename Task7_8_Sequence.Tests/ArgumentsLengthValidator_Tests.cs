using Logger;
using Moq;
using Task7_8_Sequence.Validators;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsLengthValidator_Tests
    {
        private IValidator validator;

        public ArgumentsLengthValidator_Tests()
        {
            var mockLogger = new Mock<ILogger>();
            validator = new ArgumentsLengthValidator(mockLogger.Object);
        }

        [Theory]
        [InlineData("521", "22")]
        [InlineData("0", "22")]
        [InlineData("2")]
        public void Length_Success(params string[] arguments)
        {
            bool isValidLength = validator.IsValid(arguments);

            Assert.True(isValidLength);
        }

        [Theory]
        [InlineData("521", "22", "33")]
        [InlineData()]
        public void Length_Fail(params string[] arguments)
        {
            bool isValidLength = validator.IsValid(arguments);

            Assert.False(isValidLength);
        }


        [Fact]
        public void Numbers_Null_False()
        {
            bool isValidLength = validator.IsValid(null);

            Assert.False(isValidLength);
        }
    }
}
