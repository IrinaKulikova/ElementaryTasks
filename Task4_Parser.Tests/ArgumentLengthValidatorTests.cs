using Task4_Parser.Tests.FixtureClasses;
using Task4_Parser.Validators;
using Xunit;

namespace Task4_Parser.Tests
{
    public class ArgumentLengthValidatorTests : IClassFixture<ArgumentsLengthValidatorFixture>
    {
        private readonly IValidator _validator;

        public ArgumentLengthValidatorTests(ArgumentsLengthValidatorFixture mockValidator)
        {
            _validator = mockValidator.ArgumentsLengthValidator;
        }

        [Theory]
        [InlineData("..//Resources//file.txt", "text")]
        [InlineData("..//Resources//file.txt", "text", "new text")]
        public void ArgumentLengthValidator_WithTwoOrThreeArguments_ShouldRetunsTrue
                                                (params string[] arguments)
        {
            bool isValidLength = _validator.IsValid(arguments);

            Assert.True(isValidLength);
        }


        [Theory]
        [InlineData("..//Resources//file.txt")]
        [InlineData("..//Resources//file.txt", "text", "new text", "other text")]
        public void ArgumentLengthValidator_WithInvalidCountArguments_ShouldRetunsFalse
            (params string[] arguments)
        {
            bool isValidLength = _validator.IsValid(arguments);

            Assert.False(isValidLength);
        }


        [Theory]
        [InlineData()]
        [InlineData(null)]
        public void ArgumentLengthValidator_WithOutArguments_ShouldRetunsFalse
          (params string[] arguments)
        {
            bool isValidLength = _validator.IsValid(arguments);

            Assert.False(isValidLength);
        }
    }
}
