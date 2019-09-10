using Logger;
using Moq;
using Task4_Parser.Validators;
using Xunit;

namespace Task4_Parser.Tests
{
    public class ArgumentLengthValidator_Tests
    {
        private readonly IValidator validator;

        public ArgumentLengthValidator_Tests()
        {
            var mockLogger = new Mock<ILogger>();
            validator = new ArgumentsLengthValidator(mockLogger.Object);
        }

        [Theory]
        [InlineData("..//Resources//file.exe", "text")]
        [InlineData("..//Resources//file.exe", "text", "new text")]
        public void IsValid_Success(params string[] arguments)
        {
            bool isValidLength = validator.IsValid(arguments);

            Assert.True(isValidLength);
        }


        [Theory]
        [InlineData()]
        [InlineData("..//Resources//file.exe")]
        [InlineData("..//Resources//file.exe", "text", "new text", "other text")]
        public void IsValid_Fail(params string[] arguments)
        {
            bool isValidLength = validator.IsValid(arguments);

            Assert.False(isValidLength);
        }
    }
}
